using MvcPodcast.Common.BusinessObjects;

namespace MvcPodcast.Site.Models
{
  public class ViewPodcast
  {
    public ViewPodcast()
    {
      Article = new PodcastArticle();
      ImageRelativeDirPath = string.Empty;
      PodcastRelativeDirPath = string.Empty;
    }

    //public ViewArticles(IEnumerable<NewsArticle> articles, IBlogConfiguration config)
    
    #region Public Properties
    public PodcastArticle Article
    {
      get;
      set;
    }

    public string ImageRelativeDirPath
    {
      get;
      set;
    }

    public string PodcastRelativeDirPath
    {
      get;
      set;
    }
    #endregion
  }
}