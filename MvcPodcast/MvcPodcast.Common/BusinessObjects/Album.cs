using System;
using System.Collections.Generic;

namespace MvcPodcast.Common.BusinessObjects
{
  public class Album
  {
    #region Constructors
    public Album()
    {
      Artist = string.Empty;
      Caption = string.Empty;
      CoverImageFileName = string.Empty;
      Id = 0;
      Label = string.Empty;
      ListenUrls = new List<DynamicUrl>();
      Title = string.Empty;
      Year = 0;
    } 
    #endregion

    #region Public Properties
    public string Artist { get; set; }
    public string Caption { get; set; }
    public string CoverImageFileName { get; set; }
    public Int64 Id { get; set; }
    public string Label { get; set; }
    public List<DynamicUrl> ListenUrls { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    #endregion
  }
}
