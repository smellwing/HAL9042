using HAL9042.Controls;
using HAL9042.Interfaces;
using HAL9042.Handles;
using HAL9042;

/// <summary>
/// Clase principal del programa que facilita un chat interactivo con ChatGPT.
/// </summary>
class Program
{
    /// <summary>
    /// Método principal del programa.
    /// </summary>
    /// <param name="args">Argumentos de la línea de comandos.</param>
    static async Task Main ( string[] args )
    {
        // Lista para mantener un registro del historial del chat.
        var chatHistory = new List<string> ();
        var argsList = args.ToList ();
        // Creación de una instancia del controlador ChatGPT.
        ChatGPTControl chatGPTControl = new ();
        CLIControl cliControl = new ();
        Invoker invoker = new ();

        // Si se pasan argumentos y el primer argumento es "-a"
        if (argsList.Count > 1) {
            

            if (argsList.Any (s => s == "-c"))
            {
                var index = argsList.FindIndex (s => s == "-c");
                var userInput = args[index + 1]; // Tomamos el segundo argumento como entrada del usuario
                chatHistory.Add ($"Tú: {userInput}");

                // Usando el patrón Command
                ICommand command = new HandleSendMessageCommand (chatGPTControl, userInput, true);
                invoker.SetCommand (command);
                await invoker.ExecuteCommand ();
                var response = chatGPTControl.GetResponseText ();
                Console.ResetColor ();
                Console.WriteLine ($"\t{response}");
                chatHistory.Add ($"ChatGPT: {response}");

            }
            if (argsList.Any (s => s == "-a"))
            {
                var index = argsList.FindIndex(s => s == "-a");
                var userInput = args[index+1]; // Tomamos el segundo argumento como entrada del usuario
                chatHistory.Add ($"Tú: {userInput}");

                // Usando el patrón Command
                ICommand command = new HandleSendMessageCommand (chatGPTControl, userInput);
                invoker.SetCommand (command);
                await invoker.ExecuteCommand ();

                chatHistory.Add ($"ChatGPT: {chatGPTControl.GetResponseText ()}");

                // Configura los colores de la consola para mostrar el encabezado de ChatGPT.
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine ($"Respuesta de HAL\n\r");
                Console.ResetColor ();
                Console.WriteLine ($"\t{chatGPTControl.GetResponseText ()}");
                return; // Finalizamos el programa después de responder al argumento
            }
            return;
        } else
        {

            Console.WriteLine ("¡Bienvenido al chat con HAL9042!");
            Console.WriteLine ("Escribe '/exit' para salir del chat.");
        }

        while (true)
        {
            Console.Write ("Tú: ");
            var userInput = Console.ReadLine ().Trim ();
            if (userInput is not null && userInput[0] == '/')
            {
                // Create a command to handle CLI commands and execute it.
                ICommand cliCommand = new HandleSendMessageCommand (cliControl, userInput[1..]);
                invoker.SetCommand (cliCommand);
                await invoker.ExecuteCommand ();

                //// Check if the exit command was triggered.
                if (cliControl.Exit)
                {
                    // Exit the chat loop.
                    break;
                }

            } else
            {
                // Agrega el mensaje del usuario al historial del chat.
                chatHistory.Add ($"Tú: {userInput}");

                // Usando el patrón Command
                ICommand command = new HandleSendMessageCommand (chatGPTControl, userInput);
                invoker.SetCommand (command);
                await invoker.ExecuteCommand ();

                // Agrega la respuesta de ChatGPT al historial del chat.
                chatHistory.Add ($"ChatGPT: {chatGPTControl.GetResponseText ()}");

                // Configura los colores de la consola para mostrar el encabezado de ChatGPT.
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine ($"HAL");
                Console.ResetColor ();

                // Muestra la respuesta de ChatGPT.
                Console.WriteLine ($"{chatGPTControl.GetResponseText ()}");
            }
        }

        // Mensaje de despedida al finalizar el chat.
        Console.WriteLine ("¡Chat finalizado!");
    }
}
