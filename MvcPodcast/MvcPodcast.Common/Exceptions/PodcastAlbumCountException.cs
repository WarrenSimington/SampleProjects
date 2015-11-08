
namespace MvcPodcast.Common.Exceptions
{
  public class PodcastAlbumCountException : BlogException
  {
    #region Constructors
    public PodcastAlbumCountException(int actualCount, int expectedCount)
      : base("Unexpected podcast album count.")
    {
      ActualCount = actualCount;
      ExpectedCount = expectedCount;
    } 
    #endregion

    #region Public Properties
    public int ActualCount { get; private set; }
    public int ExpectedCount { get; private set; } 
    #endregion
  }
}
