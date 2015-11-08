using System.Configuration;
using MvcPodcast.Common.Interfaces;

namespace MvcPodcast.Common.Implementation.Configuration
{
  /// <summary>
  /// Uses consuming application's web.config file for configuration values.
  /// </summary>
  public class WebConfigFile : IBlogConfiguration
  {
    #region Private Constants
    private const string KEY_IMAGE_DIRECTORY_RELATIVE_PATH = "ImageDirectoryRelativePath";
    private const string KEY_PODCAST_DIRECTORY_RELATIVE_PATH = "PodcastDirectoryRelativePath"; 
    #endregion
    
    #region IBlogConfiguration Implementation
    public string ImageDirectoryRelativePath
    {
      get
      {
        return ConfigurationManager.AppSettings[KEY_IMAGE_DIRECTORY_RELATIVE_PATH];
      }
    }

    public string PodcastDirectoryRelativePath
    {
      get
      {
        return ConfigurationManager.AppSettings[KEY_PODCAST_DIRECTORY_RELATIVE_PATH];
      }
    }
    #endregion
  }
}
