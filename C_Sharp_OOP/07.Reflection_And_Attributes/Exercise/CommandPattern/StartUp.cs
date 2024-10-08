﻿namespace CommandPattern
{
    using System;
    using Core.Commands;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
