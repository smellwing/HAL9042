using Whetstone.ChatGPT;
using Whetstone.ChatGPT.Models;

/// <summary>
/// Clase principal del programa.
/// </summary>
class Program
{

    /// <summary>
    /// Método principal del programa.
    /// </summary>
    /// <param name="args">Argumentos de la línea de comandos.</param>
    static async Task Main ( string[] args )
    {
        var chatHistory = new List<string> ();
        var exitCommand = "/exit";

        Console.WriteLine ("¡Bienvenido al chat con ChatGPT!");
        Console.WriteLine ("Escribe '/exit' para salir del chat.");

        while (true)
        {
            Console.Write ("Tú: ");
            var userInput = Console.ReadLine ();

            if (userInput is not null && userInput.Equals (exitCommand, StringComparison.OrdinalIgnoreCase))
            {
                break;
            }


            // Inicializar el cliente de ChatGPT
            using IChatGPTClient client = new ChatGPTClient ("YOUR_API_KEY");

            chatHistory.Add ($"Tú: {userInput}");

            // Acá instanciamos el objeto de respuesta
            var gptRequest = new ChatGPTChatCompletionRequest ()
            {
                Model = ChatGPT35Models.Turbo,
                Messages = new List<ChatGPTChatCompletionMessage> ()
                {
                    new ChatGPTChatCompletionMessage()
                    {
                        Role = MessageRole.User,
                        Content = userInput // Entrada del usuario
                    }
                },
                // # Tokens = $ Stream = Respuestas largas
                MaxTokens = 100
            };

            var response = await client.CreateChatCompletionAsync (gptRequest);
            var aiResponse = response?.GetCompletionText ();
            chatHistory.Add ($"ChatGPT: {aiResponse}");
            Console.WriteLine ($"ChatGPT: {aiResponse}");
        }

        Console.WriteLine ("¡Chat finalizado!");
    }
}
