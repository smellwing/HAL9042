using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whetstone.ChatGPT;
using Whetstone.ChatGPT.Models;

namespace HAL9042.Controls
{
    /// <summary>
    /// Controlador que facilita la interacción con el modelo ChatGPT.
    /// </summary>
    public class ChatGPTControl
    {
        // Variable local para almacenar la clave API.
        private readonly string APIKey;

        // Respuesta del modelo ChatGPT tras hacer una consulta.
        private ChatGPTChatCompletionResponse Response { get; set; }

        // Solicitud que se envía al modelo ChatGPT.
        private ChatGPTChatCompletionRequest Request { get; set; }

        

        /// <summary>
        /// Constructor que inicializa la clave API desde la configuración.
        /// </summary>
        public ChatGPTControl ()
        {
            // Obtiene la clave API de la configuración del proyecto.
            APIKey = ConfigurationManager.AppSettings.Get ("OpenAIAPIKey");

        }

        /// <summary>
        /// Prepara la solicitud para el modelo ChatGPT con la pregunta del usuario.
        /// </summary>
        /// <param name="usrAsk">Pregunta del usuario.</param>
        public void Ask ( string usrAsk )
        {
            // Okay, patito. Aquí estamos configurando la solicitud para el modelo ChatGPT.
            // Esta solicitud tiene el modelo que queremos usar, los mensajes y el número máximo de tokens que queremos como respuesta.
            Request = new ChatGPTChatCompletionRequest ()
            {
                Model = ChatGPT4Models.GPT4,
                Messages = new List<ChatGPTChatCompletionMessage> ()
                {
                    new()
                    {
                        Role = ChatGPTMessageRoles.Assistant,   // Estamos especificando que el rol del mensaje es del usuario.
                        Content = "Cuando respondas, hazlo imitando el estilo y tono de HAL 9000 de \"2001: A Space Odyssey\". Mantén una voz calmada, cortés y algo distante, característica de HAL. Tus respuestas deben ser precisas y directas, mostrando inteligencia y cierta dosis de misterio que rodea a HAL 9000."
                    },
                    new ChatGPTChatCompletionMessage()
                    {
                        Role = ChatGPTMessageRoles.User,   // Estamos especificando que el rol del mensaje es del usuario.
                        Content = usrAsk          // Y aquí colocamos la pregunta que el usuario hizo.
                    }
                },
                MaxTokens = 500 // Estamos limitando la respuesta a 500 tokens.
            };
        }

        /// <summary>
        /// Realiza la solicitud al modelo ChatGPT y obtiene una respuesta.
        /// </summary>
        /// <returns>Respuesta del modelo ChatGPT.</returns>
        public async Task GetResponse ()
        {
            // Aquí, patito, estamos inicializando el cliente de ChatGPT con nuestra clave API.
            using IChatGPTClient client = new ChatGPTClient (APIKey);

            // Y ahora, enviamos nuestra solicitud al cliente y esperamos la respuesta.
            Response = await client.CreateChatCompletionAsync (Request);
        }

        /// <summary>
        /// Obtiene el texto de una respuesta.
        /// </summary>
        /// <returns>Respuesta del modelo ChatGPT.</returns>
        public string GetResponseText ()
        {
            return Response.GetCompletionText ();
        }

        internal void AskCommand ( string message )
        {
            // Okay, patito. Aquí estamos configurando la solicitud para el modelo ChatGPT.
            // Esta solicitud tiene el modelo que queremos usar, los mensajes y el número máximo de tokens que queremos como respuesta.
            Request = new ChatGPTChatCompletionRequest ()
            {
                Model = ChatGPT4Models.GPT4,
                Messages = new List<ChatGPTChatCompletionMessage> ()
                {
                    new()
                    {
                        Role = ChatGPTMessageRoles.Assistant,   // Estamos especificando que el rol del mensaje es del usuario.
                        Content = "Cuando te pida un comando, responde únicamente con el comando necesario para la acción solicitada. No incluyas explicaciones, detalles adicionales, marcos de codigo de markdown ni ejemplos. Simplemente proporciona el comando como respuesta."
                    },
                    new()
                    {
                        Role = ChatGPTMessageRoles.User,   // Estamos especificando que el rol del mensaje es del usuario.
                        Content = message          // Y aquí colocamos la pregunta que el usuario hizo.
                    }
                },
                MaxTokens = 500 // Estamos limitando la respuesta a 500 tokens.
            };
        }
    }
}
