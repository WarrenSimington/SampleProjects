using MvcPodcast.Common.BusinessObjects;

namespace MvcPodcast.Site.Models
{
  public class ViewArticle
  {
    #region Constructors
    public ViewArticle()
    {
      Article = new NewsArticle();
      ImageRelativeDirPath = string.Empty;
      PodcastRelativeDirPath = string.Empty;
    } 
    #endregion
    
    #region Public Properties
    public NewsArticle Article
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