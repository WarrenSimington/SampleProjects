using MvcPodcast.Common.BusinessObjects;
using MvcPodcast.Common.Exceptions;
using MvcPodcast.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Wes.Crypto;
using Wes.Database;

namespace MvcPodcast.Common.Implementation.Repository
{
  public class MsSqlRepository : IBlogRepository
  {
    #region Constructors
    public MsSqlRepository()
    {
      AssignConnectionString();
    }
    #endregion

    #region Private Members
    private string _connectionString;

    private static byte[] _iv = new byte[]
    {
      0x50, 0xCE, 0x23, 0x89, 0x3A, 0x5D, 0xA6, 0xCF, 
      0xAB, 0x03, 0x1A, 0x6B, 0x12, 0x3E, 0xAE, 0x91
    };

    private static byte[] _key = new byte[]
    {
      0x8F, 0xE9, 0xB5, 0xF2, 0x37, 0x2D, 0x2C, 0x21, 
      0x10, 0x01, 0x06, 0x19, 0x26, 0x07, 0x08, 0x26, 
      0xE3, 0x08, 0x74, 0x2F, 0xA4, 0xAD, 0xC6, 0xA1, 
      0xED, 0x3D, 0x27, 0xFD, 0x05, 0x1F, 0xE8, 0xA3
    }; 
    #endregion

    #region Private Methods
    private void AssignConnectionString()
    {
      //Attempt to retrieve the connection string from the web.config file
      ConnectionStringSettings connStrSettings;
      if ((connStrSettings = ConfigurationManager.ConnectionStrings["MsSqlRepository"]) == null)
        throw new ConnectionStringAssignmentException();

      //We expect the connection string to be encrypted, so decrypt it
      string encryptedConnStr = connStrSettings.ConnectionString;

      Rijndael rijndael = new Rijndael(_key, _iv);
      _connectionString = rijndael.Decrypt(encryptedConnStr);
    }

    private PodcastArticle ConvertToPodcastArticle(NewsArticle newsArticle)
    {
      return (PodcastArticle)newsArticle;
    }

    private void LoadAlbumUrls(Album album)
    {
      MsSql db = new MsSql(_connectionString);
      SqlCommand command = db.GetNewCommand("GetAlbumUrls", CommandType.StoredProcedure);

      try
      {
        command.Parameters.Add("@AlbumId", SqlDbType.BigInt).Value = album.Id;
        db.AddErrorHandlingParamsToSqlCommand(command);

        SqlDataReader reader = command.ExecuteReader();
        try
        {
          int ordId = reader.GetOrdinal("Id");
          int ordDisplayText = reader.GetOrdinal("DisplayText");
          int ordUrl = reader.GetOrdinal("Url");

          while (reader.Read())
          {
            album.ListenUrls.Add(new DynamicUrl()
            {
              DisplayText = reader.GetString(ordDisplayText),
              Url = reader.GetString(ordUrl)
            });
          }
        }
        finally
        {
          reader.Close();
        }

        db.FreeCommand(command);
      }
      catch (Exception ex)
      {
        db.FreeCommand(command, false);
        throw ex;
      }
    }

    private void LoadPodcastAlbums(PodcastArticle article)
    {
      MsSql db = new MsSql(_connectionString);
      SqlCommand command = db.GetNewCommand("GetPodcastAlbums", CommandType.StoredProcedure);

      try
      {
        command.Parameters.Add("@ArticleId", SqlDbType.BigInt).Value = article.Id;
        db.AddErrorHandlingParamsToSqlCommand(command);

        SqlDataReader reader = command.ExecuteReader();
        try
        {
          int ordId = reader.GetOrdinal("Id");
          int ordArtist = reader.GetOrdinal("Artist");
          int ordCaption = reader.GetOrdinal("Caption");
          int ordCoverImageFileName = reader.GetOrdinal("CoverImageFileName");
          int ordLabel = reader.GetOrdinal("Label");
          int ordTitle = reader.GetOrdinal("Title");
          int ordYear = reader.GetOrdinal("Year");

          const int EXPECTED_ALBUM_COUNT = 2;
          int albumCount = 0;
          while (reader.Read())
          {
            //Increment our album counter
            albumCount++;

            //Make sure that we haven't surpassed the expected album count
            if (albumCount > EXPECTED_ALBUM_COUNT)
              throw new PodcastAlbumCountException(albumCount, EXPECTED_ALBUM_COUNT);

            Album newAlbum = new Album()
            {
              Artist = reader.GetString(ordArtist),
              Caption = reader.GetString(ordCaption),
              CoverImageFileName = reader.GetString(ordCoverImageFileName),
              Id = reader.GetInt64(ordId),
              Label = reader.GetString(ordLabel),
              Title = reader.GetString(ordTitle),
              Year = reader.GetInt32(ordYear)
            };

            //Get listen URLs for the album
            LoadAlbumUrls(newAlbum);

            //Assign the album to the provided article
            if (albumCount == 1)
            {
              //Podcast album #1
              article.Album1 = newAlbum;
            }
            else
            {
              //Podcast album #2
              article.Album2 = newAlbum;
            }
          }

          if (albumCount != EXPECTED_ALBUM_COUNT)
            throw new PodcastAlbumCountException(albumCount, EXPECTED_ALBUM_COUNT);
        }
        finally
        {
          reader.Close();
        }

        db.FreeCommand(command);
      }
      catch (Exception ex)
      {
        db.FreeCommand(command, false);
        throw ex;
      }
    }

    private List<NewsArticle> SelectArticles(bool podcastsOnly)
    {
      List<NewsArticle> result = new List<NewsArticle>();

      MsSql db = new MsSql(_connectionString);

      //Call the appropriate stored procedure, based on whether or not we want news and podcasts,
      //or just podcasts only
      string storedProcedureName;
      if (podcastsOnly)
        storedProcedureName = "GetPodcasts";
      else
        storedProcedureName = "GetArticles";
        
      SqlCommand command = db.GetNewCommand(storedProcedureName, CommandType.StoredProcedure);

      try
      {
        db.AddErrorHandlingParamsToSqlCommand(command);

        SqlDataReader reader = command.ExecuteReader();
        try
        {
          int ordArticleId = reader.GetOrdinal("Id");
          int ordPostDateTime = reader.GetOrdinal("PostDateTime");
          int ordBodyText = reader.GetOrdinal("BodyText");
          int ordDownloadDisplayText = reader.GetOrdinal("DownloadDisplayText");
          int ordDownloadUrl = reader.GetOrdinal("DownloadUrl");

          while (reader.Read())
          {
            //Check to see if we have podcast information for the current record
            NewsArticle newArticle;
            if ((reader[ordDownloadDisplayText] == DBNull.Value) || (reader[ordDownloadUrl] == DBNull.Value))
            {
              //We are missing podcast download info, so we have a news article
              newArticle = new NewsArticle();
            }
            else
            {
              //We have download info, so we have a podcast article
              newArticle = new PodcastArticle()
              {
                //Grab the URL download info while we're here
                PodcastUrl = new DynamicUrl()
                {
                  Url = reader.GetString(ordDownloadUrl),
                  DisplayText = reader.GetString(ordDownloadDisplayText)
                }
              };
            }

            newArticle.Id = reader.GetInt64(ordArticleId);
            newArticle.PostDateTime = reader.GetDateTime(ordPostDateTime);
            newArticle.BodyText = reader.GetString(ordBodyText);

            if (newArticle is PodcastArticle)
            {
              //We need to retrieve album information for the podcast
              LoadPodcastAlbums((PodcastArticle)newArticle);
            }

            //Add the new article to the result
            result.Add(newArticle);
          }
        }
        finally
        {
          reader.Close();
        }

        db.FreeCommand(command);
      }
      catch (Exception ex)
      {
        db.FreeCommand(command, false);
        throw ex;
      }

      return result;
    }
    #endregion

    public void DeleteArticle(long articleId)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<NewsArticle> GetArticles()
    {
      return SelectArticles(false);
    }

    public IEnumerable<PodcastArticle> GetPodcasts()
    {
      List<NewsArticle> tempResult = SelectArticles(true);
      List<PodcastArticle> result = tempResult.ConvertAll<PodcastArticle>(ConvertToPodcastArticle);
      return result;
    }

    public void InsertArticle(NewsArticle article)
    {
      throw new System.NotImplementedException();
    }

    public void UpdateArticle(NewsArticle article)
    {
      throw new System.NotImplementedException();
    }
  }
}
