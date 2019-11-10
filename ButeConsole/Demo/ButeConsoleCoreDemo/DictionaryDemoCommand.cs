using System;
using System.Collections.Generic;
using System.Text;
using ButeConsole;
using System.Linq;

namespace ButeConsoleCoreDemo
{
    public class DictionaryDemoCommand : CommandDictionary
    {
        public override string Description { get { return "use dictionary command"; } }

        public override string Title => "dict";

        public override void Run(Dictionary<string, string> param)
        {
            param.ToList().ForEach(x => Console.WriteLine($"param key={x.Key} ; param value={x.Value}"));
        }
    }
}
