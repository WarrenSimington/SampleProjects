using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using MusicSync.Common.Library;
using MusicSync.Common.Interfaces;
using MusicSync.Implementation.Exceptions;
using log4net;
using Wes.Database;

namespace MusicSync.Implementation.Repositories
{
  public class MsSqlRepository : ILibraryRepository  
  {
    #region Constructors
    public MsSqlRepository(string connectionString)
    {
      _dbObj = new MsSql(connectionString);
    } 
    #endregion

    #region Private Members
    private MsSql _dbObj;
    private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    #endregion

    #region Private Methods
    private Int64 GetMachineId(SqlCommand command)
    {
      _dbObj.ResetCommand(command);
      command.CommandText = "Library.GetWorkstationId";
      command.CommandType = CommandType.StoredProcedure;

      //Add standard param(s)
      command.Parameters.Add("@WorkstationName", SqlDbType.VarChar).Value = Environment.MachineName;

      //Create the result parameter and add it to the command
      SqlParameter paramResultMachineId = new SqlParameter("@Result", SqlDbType.BigInt)
      {
        Direction = ParameterDirection.Output
      };
      command.Parameters.Add(paramResultMachineId);

      //Add error handling params
      _dbObj.AddErrorHandlingParamsToSqlCommand(command);

      command.ExecuteNonQuery();

      _dbObj.VerifyStoredProcedureResult(command);

      Int64 result = (Int64)paramResultMachineId.Value;
      return result;
    } 
    #endregion

    #region Public Methods
    /// <summary>
    /// Instantiates and returns an MsSqlLibraryRepository object.
    /// This method retrieves connection string information from an app/web configuration file by default.
    /// </summary>
    /// <returns></returns>
    public static MsSqlRepository Load(string connectionStringName)
    {
      //Try to pull the connection string from an underlying app/web config file.
      ConnectionStringSettings connStringSettings;
      if ((connStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName]) == null)
        throw new ConnectionStringNotFoundException(connectionStringName);

      string connectionString = connStringSettings.ConnectionString;

      MsSqlRepository result = new MsSqlRepository(connectionString);

      return result;
    } 
    #endregion
    
    #region ILibraryRepository implementation
    public IEnumerable<AlbumCoverData> GetAlbumCoverData()
    {
      _log.Debug("Retrieving album cover data...");

      SqlCommand command = _dbObj.GetNewCommand("Library.GetAlbumCoverData", CommandType.StoredProcedure, false);
      
      _dbObj.AddErrorHandlingParamsToSqlCommand(command);

      SqlDataReader reader = command.ExecuteReader();
      try
      {
        int ordId = reader.GetOrdinal("Id");
        int ordDirectory = reader.GetOrdinal("Directory");
        int ordWmCollectionId = reader.GetOrdinal("WmCollectionId");
        int ordTitle = reader.GetOrdinal("Title");
          
        while (reader.Read())
        {
          AlbumCoverData albumCoverRecord = new AlbumCoverData()
          {
            Id = reader[ordId].ToString(),
            Directory = reader.GetString(ordDirectory),
            WmCollectionId = reader[ordWmCollectionId].ToString(),
            Title = reader[ordTitle].ToString()
          };

          yield return albumCoverRecord;
        }
      }
      finally
      {
        reader.Close();

        //Since it's only a select, we don't care about committing the transaction even if we
        _dbObj.FreeCommand(command);
      }
    }

    public void SaveSongLibraryInformation(IEnumerable<WmpSong> songs)
    {
      _log.Debug("Executing library synchronization insert/update...");

			//Start transaction
			SqlCommand command = _dbObj.GetNewCommand("Library.SaveSongLibraryInformation", CommandType.StoredProcedure, true);
      try
      {
        int songCount = 0;

        foreach (WmpSong song in songs)
        {
          //Increment our song counter
          songCount++;
          
          command.Parameters.Clear();
          command.Parameters.Add(new SqlParameter("@ArtistName", SqlDbType.VarChar)).Value = song.ArtistName;
          command.Parameters.Add(new SqlParameter("@AlbumTitle", SqlDbType.VarChar)).Value = song.AlbumTitle;
          command.Parameters.Add(new SqlParameter("@Duration", SqlDbType.Float)).Value = song.Duration;
          command.Parameters.Add(new SqlParameter("@SongTitle", SqlDbType.VarChar)).Value = song.SongTitle;
          command.Parameters.Add(new SqlParameter("@SongTrackingId", SqlDbType.VarChar)).Value = song.SongTrackingId;
          command.Parameters.Add(new SqlParameter("@TrackNumber", SqlDbType.Int)).Value = song.TrackNumber;
          command.Parameters.Add(new SqlParameter("@SourceURL", SqlDbType.VarChar)).Value = song.SourceUrl;
          command.Parameters.Add(new SqlParameter("@WMCollectionID", SqlDbType.VarChar)).Value = song.WmCollectionId;

          if (song.DateAdded.HasValue)
            command.Parameters.Add(new SqlParameter("@DateAdded", SqlDbType.DateTime2)).Value = song.DateAdded.Value;

          if (song.ReleaseDate.HasValue)
            command.Parameters.Add(new SqlParameter("@ReleaseDate", SqlDbType.DateTime2)).Value = song.ReleaseDate.Value;

          _dbObj.AddErrorHandlingParamsToSqlCommand(command);

          command.ExecuteNonQuery();

          _dbObj.VerifyStoredProcedureResult(command);

          if ((_log.IsDebugEnabled) && ((songCount % 250) == 0))
              _log.Info(string.Format("{0} songs pending insert/update.", songCount));
        }

				//Commit transaction
				_dbObj.FreeCommand(command, true);

        _log.Info(string.Format("Library synchronization insert/update complete ({0} songs).", songCount));
      }
      catch (Exception)
      {
				//Roll back transaction
				_dbObj.FreeCommand(command, false);
        throw;
      }
    }

    public void SaveSongUsageInformation(IEnumerable<WmpSong> songs)
    {
      _log.Debug("Executing song usage update...");

      SqlCommand command = _dbObj.GetNewCommand(true);
      
      try
      {
        //Get machine ID for usage update
        Int64 machineId = GetMachineId(command);

        //Insert song usage
        
        //Reset the command object and set it to update song usage information
        _dbObj.ResetCommand(command);
        command.CommandText = "Library.SaveSongUsageInformation";
        command.CommandType = CommandType.StoredProcedure;

        int songCount = 0;
        
        foreach (WmpSong song in songs)
        {
          //Increment our song counter
          songCount++;

          command.Parameters.Clear();
          command.Parameters.Add("@MachineId", SqlDbType.BigInt).Value = machineId;
          command.Parameters.Add("@SongTrackingId", SqlDbType.VarChar).Value = song.SongTrackingId;
          command.Parameters.Add("@ArtistName", SqlDbType.VarChar).Value = song.ArtistName;
          command.Parameters.Add("@AlbumTitle", SqlDbType.VarChar).Value = song.AlbumTitle;
          command.Parameters.Add("@SongTitle", SqlDbType.VarChar).Value = song.SongTitle;
          if (song.LastPlayed.HasValue)
            command.Parameters.Add("@LastPlayed", SqlDbType.DateTime).Value = song.LastPlayed;

          _dbObj.AddErrorHandlingParamsToSqlCommand(command);

          command.ExecuteNonQuery();

          _dbObj.VerifyStoredProcedureResult(command);

          if ((_log.IsDebugEnabled) && ((songCount % 250) == 0))
            _log.Info(string.Format("{0} songs pending insert/update.", songCount));
        }

        _dbObj.FreeCommand(command, true);

        _log.Info(string.Format("Library usage update complete ({0} songs).", songCount));
      }
      catch (Exception)
      {
        _dbObj.FreeCommand(command, false);
        throw;
      }
    }
    #endregion
  }
}
