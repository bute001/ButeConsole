using System;
using ButeConsole;

namespace ButeConsoleCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ConsoleManagement.Instance.Startup();
        }
    }
}
