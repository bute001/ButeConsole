using System;
using System.Collections.Generic;
using System.Text;

namespace ButeConsole
{
    public interface ICommand
    {
        
        string Description { get; }

        string Title { get; }



        void Run(Dictionary<string, string> param);
    }
}
