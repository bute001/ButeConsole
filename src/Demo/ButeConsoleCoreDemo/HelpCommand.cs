using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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

            ConsoleManagement.Instance.Commands.ToList().ForEach(x => Console.WriteLine($"{x.Title}\t{x.Description}"));

            Console.WriteLine("----------------end-----------------");
            Console.WriteLine();
        }
    }
}
