using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HAL9042.Controls
{
    internal class SendMessageCommand : HAL9042.Interfaces.ICommand
    {
        private readonly ChatGPTControl _control;
        private readonly string _message;

        public SendMessageCommand ( ChatGPTControl control, string message )
        {
            _control = control;
            _message = message;
        }

        public async Task Execute ()
        {
            _control.Ask (_message);
            await _control.GetResponse ();
        }
    }
}
