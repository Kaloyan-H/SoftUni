namespace CommandPattern
{
    using Core.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string args = Console.ReadLine();
                Console.WriteLine(commandInterpreter.Read(args));
            }
        }
    }
}
