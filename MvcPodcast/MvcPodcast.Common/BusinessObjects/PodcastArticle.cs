
namespace MvcPodcast.Common.BusinessObjects
{
  public class PodcastArticle : NewsArticle
  {
    #region Constructors
    public PodcastArticle()
      : base()
    {
      Album1 = new Album();
      Album2 = new Album();
      PodcastUrl = new DynamicUrl();
    } 
    #endregion

    #region Public Properties
    public Album Album1 { get; set; }
    public Album Album2 { get; set; }
    public DynamicUrl PodcastUrl { get; set; }
    #endregion
  }
}
