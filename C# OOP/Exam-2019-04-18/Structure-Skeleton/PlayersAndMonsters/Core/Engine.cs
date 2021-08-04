using System;

using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;

        public Engine(IReader reader, IWriter writer, IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
        }

        public void Run()
        {
            while (true)
            {
                string line = this.reader.ReadLine();

                if (line == "Exit")
                {
                    break;
                }

                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string output = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "AddPlayer":
                            string playerType = parts[1];
                            string playerUsername = parts[2];
                            output = this.managerController.AddPlayer(playerType, playerUsername);
                            break;
                        case "AddCard":
                            string cardType = parts[1];
                            string cardName = parts[2];
                            output = this.managerController.AddCard(cardType, cardName);
                            break;
                        case "AddPlayerCard":
                            playerUsername = parts[1];
                            cardName = parts[2];
                            output = this.managerController.AddPlayerCard(playerUsername, cardName);
                            break;
                        case "Fight":
                            string attacker = parts[1];
                            string enemy = parts[2];
                            output = this.managerController.Fight(attacker, enemy);
                            break;
                        case "Report":
                            output = this.managerController.Report();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                

                this.writer.WriteLine(output);
            }
        }
    }
}
