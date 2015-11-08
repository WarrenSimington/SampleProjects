using MusicSync.Common.Exceptions;

namespace MusicSync.Implementation.Exceptions
{
  #region ConnectionStringNotFoundException class
  /// <summary>
  /// Exception to be thrown when the named connection string cannot be located.
  /// </summary>
  public class ConnectionStringNotFoundException : MusicSyncException
  {
    #region Constructors
    public ConnectionStringNotFoundException(string connStringName)
      : base(string.Format("Connection string \"{0}\" not found.", connStringName))
    {
    }
    #endregion
  } 
  #endregion
}
