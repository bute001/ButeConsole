using System;
using System.Collections.Generic;
using System.Text;

namespace ButeConsole
{
    interface ICommand
    {
        ConsoleCommand ConsoleCommand { get; set; }

        string Description { get; }

        string Title { get; }



        void Run(Dictionary<string, string> param);
    }
}
