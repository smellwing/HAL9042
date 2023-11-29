using HAL9042.Interfaces;

namespace HAL9042.Controls;

public class CLIControl
{
    const string ExitCommand = "exit";
    const string HelpCommand = "help";
    public bool Exit { get; set; } = false;
    
    public CLIControl()
    {
        //if (userInput is not null)
        //{
        //    switch (userInput.ToLower().Trim())
        //    {
        //        case var value when value == ExitCommand:
        //            Exit = true;
        //            break;
        //        case var value when value == HelpCommand:
        //            Console.WriteLine(Help());
        //            break;
        //    }
            
        //}
    }

    public async 
    Task
Read( string command )
    {
        if(command == "exit")
        {
            Exit = true;
        }
    }
    public async Task<string> Help()
    {
        return "Comandos disponibles:\n" +
               "/exit: Salir del chat.";
    }
}