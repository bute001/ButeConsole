# ButeConsole
The simple console command integration, you can quickly use it to use commands to operate your tasks.

简易的Console指令集成，可以快速的使用他来使用命令操作你的任务。



For explame

```c#
class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ConsoleCommand consoleCommand = new ConsoleCommand();
            consoleCommand.Run();
        }
    }
```



```c#
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
```




>hello -n demo -d
>Id=0;Name=demo;HasBack=True

