using System;
using ButeConsole;

namespace ButeConsoleCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ConsoleCommand consoleCommand = new ConsoleCommand();
            consoleCommand.Run();
        }
    }
}
