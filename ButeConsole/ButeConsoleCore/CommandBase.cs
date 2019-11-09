using System;
using System.Collections.Generic;
using System.Text;

namespace ButeConsole
{
    public abstract class CommandBase<T> : ICommand
    {
        public ConsoleCommand ConsoleCommand { get; set; }

        public abstract string Description { get; }
        public abstract string Title { get; }


        public abstract void Run(T param);



        void ICommand.Run(Dictionary<string, string> param)
        {
            CommandUtil commandUtil = new CommandUtil();

            if (typeof(T) == typeof(Dictionary<string, string>))
            {
                Run((T)(object)param);
            }
            else
            {
                var resutl = commandUtil.ConvertInstance(typeof(T), param);
                Run((T)resutl);
            }
        }
    }
}
