using MvcPodcast.Common.Implementation.Configuration;
using MvcPodcast.Common.Interfaces;

namespace MvcPodcast.Site.Factories
{
  public static class ConfigurationFactory
  {
    #region Public Methods
    public static IBlogConfiguration GetInstance()
    {
      return new WebConfigFile();
    } 
    #endregion
  }
}