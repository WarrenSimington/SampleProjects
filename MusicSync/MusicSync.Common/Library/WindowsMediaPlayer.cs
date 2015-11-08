using System;
using System.Collections.Generic;
using WMPLib;

namespace MusicSync.Common.Library
{
  public static class WindowsMediaPlayer
  {
    #region Private Enums
    private enum LibraryField
    {
      AlbumTitle,
      ArtistName,
      CollectionId,
      DateAdded,
      Duration,
      LastPlayed,
      ReleaseDate,
      SongTitle,
      SongTrackingId,
      SourceUrl,
      TrackNumber
    };  
    #endregion
    
    #region Public Methods
    /// <summary>
    /// Returns a collection of Song objects from the Windows Media Player library.
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<WmpSong> GetSongsFromLibrary()
    {
      WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();
      IWMPMediaCollection media = wmp.mediaCollection;
      IWMPPlaylist pList = media.getAll();

      for (int i = 0; i < pList.count; i++)
      {
        IWMPMedia item = pList.get_Item(i);

        WmpSong currentSong = new WmpSong();
        if (item.getItemInfo("CanonicalFiletype") == "mp3")
        {
          foreach (LibraryField libField in Enum.GetValues(typeof(LibraryField)))
          {
            string attrName;
            switch (libField)
            {
              case LibraryField.AlbumTitle:
                {
                  attrName = "WM/AlbumTitle";
                  currentSong.AlbumTitle = item.getItemInfo(attrName);
                  break;
                }

              case LibraryField.ArtistName:
                {
                  attrName = "WM/AlbumArtist";
                  currentSong.ArtistName = item.getItemInfo(attrName);
                  break;
                }

              case LibraryField.CollectionId:
                {
                  attrName = "WM/WMCollectionID";
                  currentSong.WmCollectionId = item.getItemInfo(attrName);
                  break;
                }

              case LibraryField.DateAdded:
                {
                  attrName = "AcquisitionTime";
                  string dateAddedStr = item.getItemInfo(attrName);
                  //Convert from UTC time
                  DateTime utcDateAdded = DateTime.SpecifyKind(DateTime.Parse(dateAddedStr), DateTimeKind.Utc);
                  currentSong.DateAdded = utcDateAdded.ToLocalTime();
                  break;
                }

              case LibraryField.Duration:
                {
                  attrName = "Duration";
                  currentSong.Duration = double.Parse(item.getItemInfo(attrName));
                  break;
                }

              //TODO: Add Label support!

              case LibraryField.LastPlayed:
                {
                  attrName = "UserLastPlayedTime";
                  string lastPlayedStr = item.getItemInfo(attrName);
                  if (!string.IsNullOrEmpty(lastPlayedStr))
                  {
                    //Convert from UTC time
                    DateTime utcLastPlayed = DateTime.SpecifyKind(DateTime.Parse(lastPlayedStr), DateTimeKind.Utc);
                    currentSong.LastPlayed = utcLastPlayed.ToLocalTime();
                  }
                  break;
                }

              case LibraryField.ReleaseDate:
                {
                  attrName = "ReleaseDate";
                  string releaseDateStr = item.getItemInfo(attrName);
                  if (!string.IsNullOrEmpty(releaseDateStr))
                    currentSong.ReleaseDate = DateTime.Parse(releaseDateStr).Date;
                  break;
                }

              case LibraryField.SongTitle:
                {
                  attrName = "Title";
                  currentSong.SongTitle = item.getItemInfo(attrName);
                  break;
                }

              case LibraryField.SongTrackingId:
                {
                  attrName = "TrackingID";
                  currentSong.SongTrackingId = item.getItemInfo(attrName);
                  break;
                }

              case LibraryField.SourceUrl:
                {
                  attrName = "SourceURL";
                  currentSong.SourceUrl = item.getItemInfo(attrName);
                  break;
                }

              case LibraryField.TrackNumber:
                {
                  attrName = "WM/TrackNumber";
                  currentSong.TrackNumber = int.Parse(item.getItemInfo(attrName));
                  break;
                }

              default:
                continue;
            }
          }

          yield return currentSong;
        }
      }
    } 
    #endregion
  }
}
