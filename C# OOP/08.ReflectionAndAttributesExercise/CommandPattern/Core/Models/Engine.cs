using System;

using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    internal class Engine : IEngine
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
                string input = Console.ReadLine();
                string output = this.commandInterpreter.Read(input);
                Console.WriteLine(output);
            }
        }
    }
}