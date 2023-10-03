using Whetstone.ChatGPT;
using Whetstone.ChatGPT.Models;
using System.Configuration;
using HAL9042.Controls;
using System.Collections.Specialized;
using HAL9042.Invokers;
using HAL9042.Interfaces;

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

        // Comando para salir del chat.
        var exitCommand = "/exit";

        // Creación de una instancia del controlador ChatGPT.
        ChatGPTControl chatGPTControl = new ();
        ChatInvoker invoker = new ();

        // Si se pasan argumentos y el primer argumento es "-ask"
        if (args.Length > 1 && args[0] == "-ask")
        {
            var userInput = args[1]; // Tomamos el segundo argumento como entrada del usuario
            chatHistory.Add ($"Tú: {userInput}");

            // Usando el patrón Command
            ICommand command = new SendMessageCommand (chatGPTControl, userInput);
            invoker.SetCommand (command);
            await invoker.ExecuteCommand ();            
            
            chatHistory.Add ($"ChatGPT: {chatGPTControl.GetResponseText()}");

            Console.WriteLine ($"Respuesta de ChatGPT a '{userInput}': {chatGPTControl.GetResponseText ()}");
            return; // Finalizamos el programa después de responder al argumento
        }   else
        {

            Console.WriteLine ("¡Bienvenido al chat con ChatGPT!");
            Console.WriteLine ("Escribe '/exit' para salir del chat.");
        }

        while (true)
        {
            Console.Write ("Tú: ");
            var userInput = Console.ReadLine ();
            var c = new Commands(userInput);

            // Verifica si el usuario quiere salir del chat.
            if (c.Exit) break;
            

            // Agrega el mensaje del usuario al historial del chat.
            chatHistory.Add ($"Tú: {userInput}");

            // Usando el patrón Command
            ICommand command = new SendMessageCommand (chatGPTControl, userInput);
            invoker.SetCommand (command);
            await invoker.ExecuteCommand ();
                        
            // Agrega la respuesta de ChatGPT al historial del chat.
            chatHistory.Add ($"ChatGPT: {chatGPTControl.GetResponseText()}");

            // Configura los colores de la consola para mostrar el encabezado de ChatGPT.
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ($"ChatGPT");
            Console.ResetColor ();

            // Muestra la respuesta de ChatGPT.
            Console.WriteLine ($"{chatGPTControl.GetResponseText ()}");
        }

        // Mensaje de despedida al finalizar el chat.
        Console.WriteLine ("¡Chat finalizado!");
    }
}
