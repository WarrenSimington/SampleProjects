using System;

namespace MusicSync.Common.Exceptions
{
  #region HeavyMotionException class
  /// <summary>
  /// Base class for all derived custom exceptions.
  /// </summary>
  public abstract class MusicSyncException : ApplicationException
  {
    #region Constructors
    public MusicSyncException(string message)
      : base(message)
    {
    }
    #endregion
  } 
  #endregion

  #region ConfigurationFileSettingException class
  /// <summary>
  /// Exception to be used when errors are encountered retrieving expected settings from a configuration file.
  /// </summary>
  public class ConfigurationFileSettingException : MusicSyncException
  {
    #region Constructors
    public ConfigurationFileSettingException(string settingName)
      : base(string.Format("An error occured while attempting to read the following configuration file setting: {0}", settingName))
    {
    }
    #endregion
  } 
  #endregion
}
