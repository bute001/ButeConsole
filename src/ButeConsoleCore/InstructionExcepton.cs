using System;
using System.Collections.Generic;
using System.Text;

namespace ButeConsole
{
    public class InstructionExcepton : Exception
    {
        public InstructionExcepton(string message) : base(message) { }
    }
}
