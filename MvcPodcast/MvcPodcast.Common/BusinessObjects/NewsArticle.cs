using System;

namespace MvcPodcast.Common.BusinessObjects
{
  public class NewsArticle
  {
    #region Constructors
    public NewsArticle()
    {
      Id = 0;
      PostDateTime = DateTime.MinValue;
      BodyText = string.Empty;
    } 
    #endregion

    #region Public Properties
    public Int64 Id { get; set; }
    public DateTime PostDateTime { get; set; }
    public string BodyText { get; set; } 
    #endregion
  }
}
