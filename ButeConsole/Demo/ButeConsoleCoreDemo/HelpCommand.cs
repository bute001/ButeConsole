using System;
using System.Collections.Generic;
using System.Text;
using ButeConsole;

namespace ButeConsoleCoreDemo
{
    class HelpCommand : CommandNoParam
    {
        public override string Description => "Help";

        public override string Title => "help";

        public override void Run()
        {
            Console.WriteLine("this is help.");
        }
    }
}
