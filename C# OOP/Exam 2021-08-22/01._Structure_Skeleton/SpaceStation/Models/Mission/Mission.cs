using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (true)
            {
                if (planet.Items.Count == 0)
                {
                    break;
                }

                IAstronaut astronaut = astronauts.First(a => a.CanBreath);

                astronaut.Breath();
                astronaut.Bag.Items.Add(planet.Items.First());
                planet.Items.Remove(planet.Items.First());

                if (astronaut.CanBreath == false)
                {
                    astronauts.Remove(astronaut);
                }

                if (astronauts.Count == 0)
                {
                    break;
                }
            }
        }
    }
}
