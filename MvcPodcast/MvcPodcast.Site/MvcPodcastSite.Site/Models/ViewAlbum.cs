using MvcPodcast.Common.BusinessObjects;

namespace MvcPodcast.Site.Models
{
  public class ViewAlbum
  {
    #region Constructors
    public ViewAlbum()
    {
      Album = new Album();
      ImageRelativeDirPath = string.Empty;
    } 
    #endregion
    
    #region Public Properties
    public Album Album
    {
      get;
      set;
    }

    public string ImageRelativeDirPath
    {
      get;
      set;
    } 
    #endregion
  }
}