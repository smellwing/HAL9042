using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAL9042.Interfaces
{
    internal interface ICommand
    {
        Task Execute ();
    }

}
