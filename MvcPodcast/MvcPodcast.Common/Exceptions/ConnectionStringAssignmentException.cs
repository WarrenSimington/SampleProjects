
namespace MvcPodcast.Common.Exceptions
{
  public class ConnectionStringAssignmentException : BlogException
  {
    #region Constructors
    public ConnectionStringAssignmentException()
      : base("Unable to assign connection string.")
    {
    } 
    #endregion
  }
}
