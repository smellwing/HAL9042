using HAL9042.Controls;
using HAL9042.Interfaces;

namespace HAL9042.Handles
{
    /// <summary>
    /// Maneja el comando de enviar mensajes, implementando la interfaz ICommand.
    /// Esta clase puede trabajar con diferentes tipos de controles para enviar mensajes.
    /// </summary>
    internal class HandleSendMessageCommand : ICommand
    {
        // Control de ChatGPT para enviar mensajes.
        private readonly ChatGPTControl? _chatGPTControl = null;
        // Control de CLI para enviar mensajes.
        private readonly CLIControl _cliControl;

        // Mensaje a ser enviado.
        private readonly string _message;

        private readonly bool _commandsMode;

        /// <summary>
        /// Constructor para inicializar con un control de ChatGPT y un mensaje.
        /// </summary>
        /// <param name="control">Control de ChatGPT.</param>
        /// <param name="message">Mensaje a enviar.</param>
        public HandleSendMessageCommand ( ChatGPTControl control, string message , bool comandsMode = false)
        {
            _chatGPTControl = control;
            _message = message;
            _commandsMode = comandsMode;
        }

        /// <summary>
        /// Constructor sobrecargado para inicializar con un control de CLI y un mensaje.
        /// </summary>
        /// <param name="control">Control de CLI.</param>
        /// <param name="message">Mensaje a enviar.</param>
        public HandleSendMessageCommand ( CLIControl control, string message )
        {
            _cliControl = control;
            _message = message;
        }

        /// <summary>
        /// Ejecuta el comando de enviar el mensaje.
        /// </summary>
        public async Task Execute ()
        {
            // Envía el mensaje usando el control de ChatGPT.
            // Espera y obtiene la respuesta del control de ChatGPT.
            if (_chatGPTControl != null)
            {
                if (_commandsMode) {
                    _chatGPTControl.AskCommand (_message);
                }
                else {
                    _chatGPTControl.Ask (_message);
                }
                

                await _chatGPTControl.GetResponse ();
            }
            if (_cliControl != null)
            {
                _cliControl.Read (_message);
            //    await _cliControl.GetResponse ();
            }

        }
    }
}
