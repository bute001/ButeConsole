using System;
using System.Collections.Generic;
using System.Text;

namespace ButeConsole
{
    public abstract class CommandEntity<T> : ICommand
    {
        public ConsoleManagement ConsoleCommand { get; set; }

        public abstract string Description { get; }
        public abstract string Title { get; }


        public abstract void Run(T param);



        void ICommand.Run(Dictionary<string, string> param)
        {
            Util commandUtil = new Util();
            var resutl = commandUtil.ConvertInstance(typeof(T), param);
            Run((T)resutl);
        }
    }
}
