using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer()
        {
            Badges = 0;
            Pokemons = new List<Pokemon>();
        }
        public Trainer(string name)
            :this()
        {
            this.Name = name;
            
        }
        public string Name { get; set; }
        public int Badges { get; set; } 
        public List<Pokemon> Pokemons { get; set; }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }
}
