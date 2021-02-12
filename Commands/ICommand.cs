using System;
using System.Collections.Generic;
using System.Text;

namespace CityBase.Commands
{
    interface ICommand
    {
         void Run();
         string GetName();
    }
}
