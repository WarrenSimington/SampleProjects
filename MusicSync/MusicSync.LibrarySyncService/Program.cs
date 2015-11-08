using System.ServiceProcess;

namespace MusicSync.LibrarySyncService
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main()
    {
      ServiceBase[] ServicesToRun;
      ServicesToRun = new ServiceBase[] 
            { 
                new LibrarySyncService()
            };
      ServiceBase.Run(ServicesToRun);
    }
  }
}
