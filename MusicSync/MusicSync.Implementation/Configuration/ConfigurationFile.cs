using MusicSync.Common.Exceptions;
using MusicSync.Common.Interfaces;
using System;
using System.Configuration;

namespace MusicSync.Implementation.Configuration
{
  public class ConfigurationFile : IControllerConfiguration
  {
    #region Constructors
    public ConfigurationFile()
    {
      //Set defaults
      _syncIntervalMilliseconds = 60;
    } 
    #endregion

    #region Private Constants
    private const string KEY_SYNC_INTERVAL_MINUTES = "ControllerActionIntervalMilliseconds"; 
    #endregion

    #region Private Members
    private Int64 _syncIntervalMilliseconds; 
    #endregion

    #region Public Methods
    /// <summary>
    /// Instantiates a ConfigurationFile object, populates it and returns it as the result.
    /// </summary>
    /// <returns></returns>
    public static ConfigurationFile Load()
    {
      ConfigurationFile result = new ConfigurationFile();
      
      //Retrieve synchronization interval minutes
      if (!Int64.TryParse(ConfigurationManager.AppSettings[KEY_SYNC_INTERVAL_MINUTES], out result._syncIntervalMilliseconds))
        throw new ConfigurationFileSettingException(KEY_SYNC_INTERVAL_MINUTES);
      
      return result;
    } 
    #endregion
    
    #region IControllerConfiguration Members
    Int64 IControllerConfiguration.ControllerActionIntervalMilliseconds
    {
      get
      {
        return _syncIntervalMilliseconds;
      }
    }

    #endregion
  }
}
