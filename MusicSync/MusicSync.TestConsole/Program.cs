using MusicSync.Common.Interfaces;
using MusicSync.Common.ServiceControllers;
using MusicSync.Implementation.Configuration;
using MusicSync.Implementation.Repositories;
using System;

namespace MusicSync.TestConsole
{
  class Program
  {
    #region Private Enums
    private enum ConsoleAction { None, Exit, StartLibraryController, StartUsageController }; 
    #endregion
    
    static void Main(string[] args)
    {
      try
      {
        //Prompt for the type of controller to start
        ConsoleAction actionToPerform = ConsoleAction.None;
        do
        {
          Console.WriteLine("Select controller to start. Press <Esc> to exit:");
          Console.WriteLine();
          Console.WriteLine("1) Library Sync Controller");
          Console.WriteLine("2) Usage Sync Controller");
          Console.WriteLine();
          ConsoleKeyInfo userInput = Console.ReadKey(true);

          switch (userInput.Key)
          {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
              {
                actionToPerform = ConsoleAction.StartLibraryController;
                break;
              }

            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
              {
                actionToPerform = ConsoleAction.StartUsageController;
                break;
              }

            case ConsoleKey.Escape:
              {
                actionToPerform = ConsoleAction.Exit;
                break;
              }

            default:
              {
                //Clear the console. We'll prompt the user again.
                Console.Clear();
                break;
              }
          }
        }
        while (actionToPerform == ConsoleAction.None);

        //Create the configuration implementation to be used for the synchronization.
        IControllerConfiguration config = ConfigurationFile.Load();

        //Create the repository implementation to be used for the synchronization.
        ILibraryRepository repository = MsSqlRepository.Load("MsSql");

        BaseController controller = null;
        switch (actionToPerform)
        {
          case ConsoleAction.Exit:
            {
              Console.WriteLine("Exiting application...");
              return;
            }

          case ConsoleAction.StartLibraryController:
            {
              Console.WriteLine("Starting library sync controller...");

              controller = new LibrarySyncController<ImageFileRepository>();
              break;
            }

          case ConsoleAction.StartUsageController:
            {
              Console.WriteLine("Starting usage sync controller...");

              controller = new UsageSyncController();
              break;
            }
        }

        //Start the controller
        controller.Start(config, repository);

        //Wait for the user to stop the controller.
        Console.WriteLine("Controller started. Press any key to stop and exit.");
        Console.ReadKey();
        Console.WriteLine("Stopping controller...");

        //Kill it
        controller.Stop();
      }
      catch (Exception ex)
      {
        Console.WriteLine("**ERROR** - {0}", ex);
        Console.ReadKey();
      }
    }
  }
}
