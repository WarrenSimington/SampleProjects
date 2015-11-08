using System.Collections.Generic;
using MvcPodcast.Common.BusinessObjects;
using MvcPodcast.Common.Interfaces;

namespace MvcPodcast.Site.Models
{
  public class ViewArticles
  {
    #region Constructors
    public ViewArticles()
    {
      Articles = new NewsArticle[0];
      ImageRelativePath = string.Empty;
      PodcastRelativePath = string.Empty;
    }

    public ViewArticles(IEnumerable<NewsArticle> articles, IBlogConfiguration config)
    {
      Articles = articles;
      ImageRelativePath = config.ImageDirectoryRelativePath;
      PodcastRelativePath = config.PodcastDirectoryRelativePath;
    }
    #endregion
    
    #region Public Properties
    public IEnumerable<NewsArticle> Articles { get; set; }

    public string ImageRelativePath { get; set; }

    public string PodcastRelativePath { get; set; }

    public string ViewCaption { get; set; }
    #endregion
  }
}