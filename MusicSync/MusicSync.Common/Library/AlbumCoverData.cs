
namespace MusicSync.Common.Library
{
  public class AlbumCoverData
  {
    #region Constructors
    public AlbumCoverData()
    {
      Id = string.Empty;
      Directory = string.Empty;
      Title = string.Empty;
      WmCollectionId = string.Empty;
    } 
    #endregion
    
    #region Public Properties
    public string Id
    {
      get;
      set;
    }

    public string Directory
    {
      get;
      set;
    }

    public string Title 
    { 
      get; 
      set; 
    }
    
    public string WmCollectionId
    {
      get;
      set;
    } 

    #endregion
  }
}
