using HAL9042.Interfaces;

namespace HAL9042.Invokers
{
    internal class ChatInvoker
    {
        private ICommand _command;

        public void SetCommand ( ICommand command )
        {
            _command = command;
        }

        public async Task ExecuteCommand ()
        {
            await _command.Execute ();
        }
    }
}
