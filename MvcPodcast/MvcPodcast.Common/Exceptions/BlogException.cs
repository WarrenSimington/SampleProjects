using System;

namespace MvcPodcast.Common.Exceptions
{
  public abstract class BlogException : ApplicationException
  {
    #region Constructors
    public BlogException(string message)
      : base(message)
    {
    }

    public BlogException(string message, Exception innerException)
      : base(message, innerException)
    {
    } 
    #endregion
  }
}
