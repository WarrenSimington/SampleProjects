using MusicSync.Common.Library;
using System.Collections.Generic;

namespace MusicSync.Common.Interfaces
{
  public interface ILibraryRepository
  {
    /// <summary>
    /// Returns album cover information contained in the repository.
    /// </summary>
    /// <returns></returns>
    IEnumerable<AlbumCoverData> GetAlbumCoverData();
    
    /// <summary>
    /// Inserts/updates a song's information in the repository.
    /// </summary>
    /// <param name="song"></param>
    void SaveSongLibraryInformation(IEnumerable<WmpSong> songs);

    /// <summary>
    /// Inserts/updates a song's usage information in the repository.
    /// </summary>
    /// <param name="songs"></param>
    void SaveSongUsageInformation(IEnumerable<WmpSong> songs);
  }
}
