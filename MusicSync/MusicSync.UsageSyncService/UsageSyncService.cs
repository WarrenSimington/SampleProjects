using MusicSync.Common.Interfaces;
using MusicSync.Common.ServiceControllers;
using MusicSync.Implementation.Configuration;
using MusicSync.Implementation.Repositories;
using log4net;
using System;
using System.Reflection;
using System.ServiceProcess;

namespace MusicSync.UsageSyncService
{
  public partial class UsageSyncService : ServiceBase
  {
    #region Constructors
    public UsageSyncService()
    {
      InitializeComponent();
    } 
    #endregion

    #region Private Members
    private IControllerConfiguration _configuration;
    private UsageSyncController _controller;
    private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    private ILibraryRepository _repository;
    #endregion

    #region Protected Methods
    protected override void OnStart(string[] args)
    {
      try
      {
        //Instantiate the configuration implementation to be used
        _configuration = ConfigurationFile.Load();

        //Instantiate the repository implementation to be used
        _repository = MsSqlRepository.Load("MsSql"); //TODO: Implement dependency injection

        //Instantiate and start the controller
        _controller = new UsageSyncController();
        _controller.Start(_configuration, _repository);
      }
      catch (Exception ex)
      {
        _log.Fatal("Error starting service.", ex);
      }
    }

    protected override void OnStop()
    {
      try
      {
        _controller.Stop();
      }
      catch (Exception ex)
      {
        _log.Fatal("Error stopping service.", ex);
      }
    } 
    #endregion
  }
}
