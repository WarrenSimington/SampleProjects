
namespace MvcPodcast.Common.Interfaces
{
  public interface IBlogConfiguration
  {
    #region Public Properties
    string ImageDirectoryRelativePath
    {
      get;
    }

    string PodcastDirectoryRelativePath
    {
      get;
    }
    #endregion
  }
}
