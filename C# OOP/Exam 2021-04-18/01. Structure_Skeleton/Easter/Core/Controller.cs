using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            Bunny bunny;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            Dye dye = new Dye(power);
            IBunny bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            bunny.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            Egg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = eggs.FindByName(eggName);

            IWorkshop workshop = new Workshop();

            var sortedBunnies = bunnies.Models
                .Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy)
                .ToList();

            if (sortedBunnies.Count == 0 )
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            while (sortedBunnies.Any())
            {
                IBunny bunny = sortedBunnies.First();

                while (true)
                {
                    if (bunny.Energy == 0 || bunny.Dyes.All(d => d.IsFinished()))
                    {
                        sortedBunnies.Remove(bunny);
                        break;
                    }

                    workshop.Color(egg, bunny);

                    if (egg.IsDone())
                    {
                        break;
                    }
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            if (egg.IsDone())
            {
                return string.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                return string.Format(OutputMessages.EggIsNotDone, eggName);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            int countColoredEggs = eggs.Models.Where(e => e.IsDone() == true).ToList().Count;
            sb.AppendLine($"{countColoredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.Append($"Dyes: {bunny.Dyes.Where(d => d.IsFinished() == false).ToList().Count} not finished" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
