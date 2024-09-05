namespace CommandPattern
{
    using System;
    using Core.Contracts;
    using System.Reflection;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] argsArray = args.Split();

            //string commandName = argsArray[0] + "Command";
            string commandName = argsArray[0];

            string[] commandArgs = argsArray.Skip(1).ToArray();

            //Type commandType = Assembly.GetCallingAssembly().GetTypes().First(x => x.Name == commandName);
            Type commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t) && t != typeof(ICommand))
                .Where(t => t.Name.StartsWith(commandName)).First();

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            return command.Execute(commandArgs);
        }
    }
}
