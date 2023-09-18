using Whetstone.ChatGPT;
using Whetstone.ChatGPT.Models;
using System.Configuration;
using HAL9042.Controls;
using System.Collections.Specialized;

/// <summary>
/// Clase principal del programa que facilita un chat interactivo con ChatGPT.
/// </summary>
class Program
{
    /// <summary>
    /// Método principal del programa.
    /// </summary>
    /// <param name="args">Argumentos de la línea de comandos.</param>
    static void Main ( string[] args )
    {
        // Lista para mantener un registro del historial del chat.
        var chatHistory = new List<string> ();

        // Comando para salir del chat.
        var exitCommand = "/exit";

        Console.WriteLine ("¡Bienvenido al chat con ChatGPT!");
        Console.WriteLine ("Escribe '/exit' para salir del chat.");

        // Creación de una instancia del controlador ChatGPT.
        ChatGPTControl chatGPTControl = new ();

        while (true)
        {
            Console.Write ("Tú: ");
            var userInput = Console.ReadLine ();

            // Verifica si el usuario quiere salir del chat.
            if (userInput is not null && userInput.Equals (exitCommand, StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            // Agrega el mensaje del usuario al historial del chat.
            chatHistory.Add ($"Tú: {userInput}");

            // Realiza una pregunta al controlador ChatGPT.
            chatGPTControl.Ask (userInput);

            // Obtiene la respuesta de ChatGPT.
            var aiResponse = chatGPTControl.Complete ();

            // Agrega la respuesta de ChatGPT al historial del chat.
            chatHistory.Add ($"ChatGPT: {aiResponse.Result.GetCompletionText ()}");

            // Configura los colores de la consola para mostrar el encabezado de ChatGPT.
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ($"ChatGPT");
            Console.ResetColor ();

            // Muestra la respuesta de ChatGPT.
            Console.WriteLine ($"{aiResponse.Result.GetCompletionText ()}");
        }

        // Mensaje de despedida al finalizar el chat.
        Console.WriteLine ("¡Chat finalizado!");
    }
}
