using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"

            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] inputParts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string trainerName = inputParts[0];
                string pokemonName = inputParts[1];
                string pokemonElement = inputParts[2];
                int pokemonHealth = int.Parse(inputParts[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainers.Add(trainerName, trainer);
                }
                trainers[trainerName].AddPokemon(pokemon);

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var trainer in trainers.Values)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);
                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }

                command = Console.ReadLine();
            }

            trainers = trainers.OrderByDescending(t => t.Value.Badges)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var trainer in trainers)
            {
                Console.WriteLine(trainer.Value.ToString());
            }
        }
    }
}
