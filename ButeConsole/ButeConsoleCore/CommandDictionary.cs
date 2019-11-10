using System;
using System.Collections.Generic;
using System.Text;

namespace ButeConsole
{
    public abstract class CommandDictionary : ICommand
    {
        public ConsoleCommand ConsoleCommand { get; set; }

        public abstract string Description { get; }
        public abstract string Title { get; }


        public abstract void Run(Dictionary<string, string> param);
    }
}
