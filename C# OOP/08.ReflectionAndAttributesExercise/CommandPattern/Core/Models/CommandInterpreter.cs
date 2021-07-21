using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    internal class CommandInterpreter : ICommandInterpreter
    {
        public CommandInterpreter()
        {
        }

        public string Read(string args)
        {
            string[] tokens = args.Split();
            string commandName = tokens[0];
            string[] commandArgs = tokens[1..];

            Type assembly = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(n => n.Name == $"{commandName}Command");

            ICommand command = (ICommand)Activator.CreateInstance(assembly);

            //ICommand command = default;

            //if (commandName == "Hello")
            //{
            //    command = new HelloCommand();
            //}
            //else if (commandName == "Exit")
            //{
            //    command = new ExitCommand();
            //}

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}