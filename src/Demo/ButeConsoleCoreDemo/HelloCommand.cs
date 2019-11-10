using System;
using System.Collections.Generic;
using System.Text;
using ButeConsole;
using static ButeConsoleCoreDemo.HelloCommand;

namespace ButeConsoleCoreDemo
{
    class HelloCommand : CommandEntity<Hello>
    {
        public class Hello
        {
            public int Id { get; set; }

            [CommandParam(IsNotBlank =true,Name ="n")]
            public string Name { get; set; }


            [CommandParam(Name = "d")]
            public bool HasBack { get; set; }

            public override string ToString()
            {
                return $"Id={Id};Name={Name};HasBack={HasBack}";
            }
        }

        public override string Description => "Hello Bute Console Core";

        public override string Title => "hello";

        public override void Run(Hello param)
        {
            Console.WriteLine(param);

        }

    }



}
