using MusicSync.Common.Interfaces;
using MusicSync.Common.Library;

namespace MusicSync.Common.ServiceControllers
{
  public class LibrarySyncController<T> : BaseController 
      where T : ILibraryImageRepository, new()
  {
    public LibrarySyncController()
      : base()
    {
      _imageRepository = new T();
    }

    #region Private Members
    private ILibraryImageRepository _imageRepository;
    #endregion

    #region Protected Methods
    /// <summary>
    /// Synchronizes music library information with the repository.
    /// </summary>
    protected override void PerformControllerAction()
    {
      _log.Info("Performing library data synchronization...");
      _repository.SaveSongLibraryInformation(WindowsMediaPlayer.GetSongsFromLibrary());
      _log.Info("Library data synchronization complete.");

      _log.Info("Performing library image synchronization...");
      _imageRepository.SaveLibraryImages(_repository);
      _log.Info("Library image synchronization complete.");
    }
    #endregion
  }
}
