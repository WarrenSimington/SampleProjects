using MvcPodcast.Common.Implementation.Repository;
using MvcPodcast.Common.Interfaces;
using log4net;
using System;
using System.Reflection;

namespace MvcPodcast.Site.Factories
{
  public static class RepositoryFactory
  {
    #region Private Members
    private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType); 
    #endregion
    
    #region Public Methods
    public static IBlogRepository GetInstance()
    {
      IBlogRepository result = null;
      
      try
      {
        //result = new TestRepository();
        result = new MsSqlRepository();
      }
      catch (Exception ex)
      {
        _log.Error("RepositoryFactory.GetInstance()", ex);
      }

      return result;
    } 
    #endregion
  }
}