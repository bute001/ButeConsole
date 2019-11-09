using System;
using System.Collections.Generic;
using System.Text;

namespace ButeConsole
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CommandParamAttribute : Attribute
    {

        public string Name { get; set; }
        public bool Required { get; set; }
        public bool IsNotBlank { get; set; }
    }
}
