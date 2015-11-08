using MusicSync.Common.Library;

namespace MusicSync.Common.ServiceControllers
{
  public class UsageSyncController : BaseController
  {
    #region Protected Methods
    /// <summary>
    /// Writes song usage information to the repository.
    /// </summary>
    protected override void PerformControllerAction()
    {
      _log.Info("Updating song usage information...");
      _repository.SaveSongUsageInformation(WindowsMediaPlayer.GetSongsFromLibrary());
      _log.Info("Song usage update complete.");
    } 
    #endregion
  }
}
