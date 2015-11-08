using MvcPodcast.Common.BusinessObjects;
using System;
using System.Collections.Generic;

namespace MvcPodcast.Common.Interfaces
{
  public interface IBlogRepository
  {
    void DeleteArticle(Int64 articleId);
    IEnumerable<NewsArticle> GetArticles();
    IEnumerable<PodcastArticle> GetPodcasts();
    void InsertArticle(NewsArticle article);
    void UpdateArticle(NewsArticle article);
  }
}
