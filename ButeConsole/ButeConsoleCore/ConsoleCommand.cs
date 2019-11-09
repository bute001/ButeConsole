using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ButeConsole
{
    public class ConsoleCommand
    {
        public System.ConsoleColor ForegrundColor { get; set; } = ConsoleColor.Gray;

        public string LeftSymbol { get; set; } = ">";


        public void Run()
        {
            do
            {
                Console.ForegroundColor = ForegrundColor;
                Console.Write(LeftSymbol);

                var text = Console.ReadLine();

                try
                {
                    Parsing.Instance.Run(this, text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (true);
        }
    }
}
