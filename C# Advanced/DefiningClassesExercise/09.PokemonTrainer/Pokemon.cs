namespace _09.PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon(string name,string element,int health)
        {
            this.PokemonName = name;
            this.Element = element;
            this.Health = health;
        }
        public string PokemonName { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}