using MvcPodcast.Common.BusinessObjects;
using MvcPodcast.Common.Interfaces;
using MvcPodcast.Site.Factories;
using MvcPodcast.Site.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcPodcast.Site.Controllers
{
  public class ArticlesController : Controller
  {
    #region Private Constants
    private const string VIEW_ARTICLES = "Articles"; 
    #endregion

    #region Public Methods
    public ActionResult News()
    {
      //Pull the news articles to show
      IEnumerable<NewsArticle> articles = RepositoryFactory.GetInstance().GetArticles();

      //Get configuration information
      IBlogConfiguration config = ConfigurationFactory.GetInstance();

      ViewArticles articleCollection = new ViewArticles(articles, config)
      {
        ViewCaption = "NEWS"
      };

      return View(VIEW_ARTICLES, articleCollection);
    }

    public ActionResult Podcasts()
    {
      //Pull the news articles to show
      IEnumerable<NewsArticle> articles = RepositoryFactory.GetInstance().GetPodcasts();

      //Get configuration information
      IBlogConfiguration config = ConfigurationFactory.GetInstance();

      ViewArticles articleCollection = new ViewArticles(articles, config)
      {
        ViewCaption = "PODCASTS"
      };

      return View(VIEW_ARTICLES, articleCollection);
    } 
    #endregion
  }
}