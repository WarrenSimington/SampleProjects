using System;

namespace MusicSync.Common.Interfaces
{
  public interface IControllerConfiguration
  {
    #region Properties
    /// <summary>
    /// Interval, in minutes, between each time the controller takes action.
    /// </summary>
    Int64 ControllerActionIntervalMilliseconds { get; } 
    #endregion
  }
}
