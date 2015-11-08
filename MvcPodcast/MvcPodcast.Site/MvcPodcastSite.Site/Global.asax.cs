using MvcPodcast.Site.Factories;
using log4net;
using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcPodcast.Site
{
  public class MvcApplication : System.Web.HttpApplication
  {
    #region Private Members
    private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType); 
    #endregion

    #region Private Methods
    private void InitializeLogging()
    {
      log4net.Config.XmlConfigurator.Configure();
      _log.Debug("Logging initialized.");
    } 
    #endregion
    
    #region Protected Methods
    protected void Application_Start()
    {
      try
      {
        //Initialize logging before we do anything
        InitializeLogging();

        AreaRegistration.RegisterAllAreas();
        RouteConfig.RegisterRoutes(RouteTable.Routes);
      }
      catch (Exception ex)
      {
        _log.Fatal("MvcApplication.Application_Start()", ex);
      }
    }

    protected void Application_Error(object sender, EventArgs e)
    {
      try
      {
        Exception ex = Server.GetLastError();
        _log.Error("General application error handled.", ex);
      }
      catch (Exception ex)
      {
        _log.Fatal("MvcApplication.Application_Error()", ex);
      }
    }

    protected void Session_Start(object sender, EventArgs e)
    {
    }
    #endregion
  }
}
