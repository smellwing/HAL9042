using HAL9042.Interfaces;

namespace HAL9042
{
    /// <summary>
    /// Esta clase representa un invocador para comandos, siguiendo el patrón de diseño Command.
    /// Permite asignar un comando y ejecutarlo.
    /// </summary>
    internal class Invoker
    {
        // Campo para almacenar la referencia al comando actual.
        private ICommand _command;

        /// <summary>
        /// Asigna el comando a ser ejecutado por este invocador.
        /// </summary>
        /// <param name="command">El comando a asignar.</param>
        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        /// <summary>
        /// Ejecuta el comando asignado.
        /// Es un método asíncrono.
        /// </summary>
        public async Task ExecuteCommand()
        {
            // Verifica si hay un comando asignado antes de intentar ejecutarlo.
            if (_command != null)
            {
                await _command.Execute();
            }
        }
    }
}
