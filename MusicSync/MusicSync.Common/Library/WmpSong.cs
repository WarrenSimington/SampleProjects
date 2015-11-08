using System;
using System.IO;

namespace MusicSync.Common.Library
{
  public class WmpSong
  {
    #region Constructors
    public WmpSong()
    {
      AlbumTitle = string.Empty;
      ArtistName = string.Empty;
      WmCollectionId = string.Empty;
      DateAdded = null;
      Duration = 0;
      LastPlayed = null;
      ReleaseDate = null;
      SongTitle = string.Empty;
      SongTrackingId = string.Empty;
      SourceUrl = string.Empty;
      TrackNumber = 0;
    } 
    #endregion

    #region Public Properties
    public string AlbumTitle
    {
      get;
      set;
    }
    
    public string ArtistName
    {
      get;
      set;
    }

    public string WmCollectionId
    {
      get;
      set;
    }

    public DateTime? DateAdded
    {
      get;
      set;
    }

    public double Duration
    {
      get;
      set;
    }

    public DateTime? LastPlayed
    {
      get;
      set;
    }

    public DateTime? ReleaseDate
    {
      get;
      set;
    }

    public string SongTitle
    {
      get;
      set;
    }
    
    public string SongTrackingId
    {
      get;
      set;
    }

    public string SourceUrl
    {
      get;
      set;
    }

    public int TrackNumber
    {
      get;
      set;
    }
    #endregion
  }
}
