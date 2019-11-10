using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace ButeConsole
{
    public sealed class ConsoleManagement
    {
        private ConsoleManagement()
        {
            Init();
        }

        public static readonly ConsoleManagement _instance = new ConsoleManagement();

        public static ConsoleManagement Instance => _instance;


        public System.ConsoleColor ForegrundColor { get; set; } = ConsoleColor.Gray;

        public string LeftSymbol { get; set; } = ">";

        Dictionary<string, ICommand> _instructions = new Dictionary<string, ICommand>();

        public ICommand[] Commands => _instructions.Values.ToArray();

        public void Startup()
        {
            do
            {
                Console.ForegroundColor = ForegrundColor;
                Console.Write(LeftSymbol);

                var text = Console.ReadLine();

                try
                {
                    Run(text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (true);
        }

        void Init()
        {
            foreach (var type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()))
            {
                if (type.IsClass && !type.IsAbstract && type.GetTypeInfo().ImplementedInterfaces.Any(x => x == typeof(ICommand)))
                {
                    object newObject = Activator.CreateInstance(type);
                    if (newObject is ICommand command)
                    {
                        if (string.IsNullOrEmpty(command.Title))
                        {
                            throw new NullReferenceException($"{type}.title");
                        }

                        var title = command.Title.ToLower();

                        if (_instructions.ContainsKey(title))
                        {
                            throw new InstructionExcepton($"{type}.title repeat.");
                        }
                        else
                        {
                            _instructions.Add(title, command);
                        }

                    }
                }
            }
        }

        private Dictionary<string, string> HandleParam(string param)
        {
            var array = param.Split(" ", StringSplitOptions.RemoveEmptyEntries);


            Dictionary<string, string> result = new Dictionary<string, string>();
            for (int i = 0; i < array.Length; i++)
            {
                var paramText = array[i].Trim();

                if (paramText == "-")
                {
                    throw new InstructionExcepton("can not only \"-\"");
                }
                else if (paramText.StartsWith('-'))
                {
                    if (i < array.Length - 1)
                    {
                        var mayValueText = array[i + 1].Trim();
                        if (mayValueText.StartsWith('-'))
                        {
                            result.Add(paramText.Substring(1), null);
                        }
                        else
                        {
                            result.Add(paramText.Substring(1), mayValueText);
                        }
                    }
                    else
                    {
                        result.Add(paramText.Substring(1), null);
                    }
                }
                else
                {
                    if (i == 0 || !array[i - 1].StartsWith('-'))
                    {
                        throw new InstructionExcepton("param error");
                    }


                    continue;
                }
            }

            return result;
        }

        private void Run(string text)
        {
            if (text != null && text.StartsWith(LeftSymbol))
            {
                text = text.Substring(LeftSymbol.Length + 1);
            }

            if (string.IsNullOrEmpty(text))
            {
                return;
            }


            var key = _instructions.Keys.FirstOrDefault(x => text.StartsWith(x));
            if (string.IsNullOrEmpty(key))
            {
                throw new InstructionExcepton("no command.");
            }


            string param = string.Empty;
            if (text.Length > key.Length)
            {
                param = text.Substring(key.Length + 1);
            }

            var dictionary = HandleParam(param);
            _instructions[key].Run(dictionary);

        }
    }
}
