using HAL9042.Controls;
using HAL9042.Interfaces;
namespace HAL9042.Handles
{

    public class HandleCLICommand : ICommand
    {
        private readonly CLIControl _cliCommands;
        private readonly string _message;


        public HandleCLICommand ( CLIControl control, string command )
        {
            _cliCommands = control;
            _message = command;
        }

        public async Task Execute ()
        {
            // Handle the CLI command by calling the appropriate method in the ICLICommands implementation.
            if (_cliCommands.Exit)
            {
                // Return true if the exit command was triggered.
                //  return true;
            } else
            {
                // Handle other commands here.
                Console.WriteLine (_cliCommands.Help ());
                // return false; // Return false for other commands.
            }
        }
    }
}