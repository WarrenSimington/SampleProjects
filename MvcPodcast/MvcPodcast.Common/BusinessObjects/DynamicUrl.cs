
namespace MvcPodcast.Common.BusinessObjects
{
  public class DynamicUrl
  {
    #region Constructors
    public DynamicUrl()
    {
      DisplayText = string.Empty;
      Url = string.Empty;
    } 
    #endregion
    
    #region Public Properties
    public string DisplayText { get; set; }
    public string Url { get; set; }
    #endregion
  }
}
