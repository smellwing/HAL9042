using Whetstone.ChatGPT;
using Whetstone.ChatGPT.Models;

class Program
{
    

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
            using IChatGPTClient client = new ChatGPTClient ("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");

            chatHistory.Add ($"Tú: {userInput}");

            var gptRequest = new ChatGPTChatCompletionRequest ()
            {
                Model = ChatGPT35Models.Turbo,
                Messages = new List<ChatGPTChatCompletionMessage> ()
                {
                    new ChatGPTChatCompletionMessage()
                    {
                        Role = MessageRole.User,
                    }
                },               
            };
            
            var response = await client.CreateChatCompletionAsync (gptRequest);
            var aiResponse = response?.GetCompletionText ();
            chatHistory.Add ($"ChatGPT: {aiResponse}");
            Console.WriteLine ($"ChatGPT: {aiResponse}");

        }
        Console.WriteLine ("¡Chat finalizado!");

    }        
}