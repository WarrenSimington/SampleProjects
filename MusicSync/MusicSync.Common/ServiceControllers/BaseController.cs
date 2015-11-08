using MusicSync.Common.Interfaces;
using log4net;
using System;
using System.Reflection;
using System.Timers;

namespace MusicSync.Common.ServiceControllers
{
  /// <summary>
  /// Base class used for HeavyMotion service controllers.
  /// </summary>
  public abstract class BaseController
  {
    #region Constructors
    public BaseController()
    {
      _isFirstPass = true;
      
      //Initialize our logger
      _log = LogManager.GetLogger(this.GetType());
    } 
    #endregion
    
    #region Private Members
    private bool _isFirstPass; 
    #endregion
    
    #region Private Methods
    /// <summary>
    /// Deactivates/stops the controller.
    /// </summary>
    private void Deactivate()
    {
      _log.Debug("Executing controller deactivation...");

      _log.Debug("Disabling action timer.");
      _actionTimer.Enabled = false;

      _log.Debug("Controller deactivation complete.");
    }

    /// <summary>
    /// Initializes/starts the controller.
    /// </summary>
    private void Initialize()
    {
      _log.Debug("Executing controller initialization...");

      //Create the timer that will "wake up" the controller and perform the main controller
      //action. We initially set the interval value to a short period to ensure that it executes
      //shortly after startup. Once the service executes, the interval is set to the configured
      //value.
      const int INITIAL_TIMER_MILLISECONDS = 5000;

      _log.Debug(string.Format("Instantiating/starting timer; interval milliseconds = {0}.", INITIAL_TIMER_MILLISECONDS));
      _actionTimer = new Timer(INITIAL_TIMER_MILLISECONDS);
      _actionTimer.Elapsed += OnActionTimerElapsed;
      _actionTimer.Start();

      _log.Debug("Controller initialization complete.");
    }

    private void OnActionTimerElapsed(object sender, ElapsedEventArgs e)
    {
      try
      {
        _log.Debug("Synchronization timer elapsed.");

        //Disable the action timer
        _log.Debug("Disabling action timer...");
        _actionTimer.Enabled = false;
        try
        {
          //Perform the controller action
          PerformControllerAction();
        }
        finally
        {
          //Check to see if it's our first pass. If so, assign the correct interval going forward
          if (_isFirstPass)
          {
            _log.Debug(string.Format("Initial pass detected. Resetting interval to {0} milliseconds.", 
                _configuration.ControllerActionIntervalMilliseconds));

            //Assign the interval to use after the first run
            _actionTimer.Interval = _configuration.ControllerActionIntervalMilliseconds;

            //Reset the variable so that we don't try to set the interval the next time around
            _isFirstPass = false;
          }

          //Make sure that the action timer is re-enabled
          _log.Debug("Re-enabling action timer...");
          _actionTimer.Enabled = true;
        }
      }
      catch (Exception ex)
      {
        _log.Error("Controller action error.", ex);
      }
    }
    #endregion
    
    #region Protected Members
    protected Timer _actionTimer;
    protected IControllerConfiguration _configuration;
    protected ILog _log;
    protected ILibraryRepository _repository;
    #endregion

    #region Protected Methods
    protected abstract void PerformControllerAction();
    #endregion
    
    #region Public Methods
    /// <summary>
    /// Starts the controller.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="repository"></param>
    public void Start(IControllerConfiguration configuration, ILibraryRepository repository)
    {
      try
      {
        _log.Debug("Starting controller...");

        //Store objects internally
        _configuration = configuration;
        _repository = repository;

        //Initialize the controller and get things moving
        Initialize();

        _log.Info("Controller started.");
      }
      catch (Exception ex)
      {
        _log.Fatal("Error starting controller.", ex);
        throw ex;
      }
    }

    /// <summary>
    /// Stops the controller.
    /// </summary>
    public void Stop()
    {
      try
      {
        _log.Debug("Stopping controller...");

        //Shut the controller down
        Deactivate();

        _log.Info("Controller stopped.");
      }
      catch (Exception ex)
      {
        _log.Fatal("Error stopping controller.", ex);
        throw ex;
      }
    } 
    #endregion
  }
}
