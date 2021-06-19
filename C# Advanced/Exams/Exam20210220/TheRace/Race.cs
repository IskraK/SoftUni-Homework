using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> Racers;
        public Race(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            Racers = new List<Racer>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return Racers.Count;
            }
        }

        public void Add(Racer Racer)
        {
            if (Capacity > Count)
            {
                Racers.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            if (Racers.Any(n => n.Name == name))
            {
                Racer racerToRemove = Racers.FirstOrDefault(n => n.Name == name);
                Racers.Remove(racerToRemove);
                return true;
            }
            return false;
        }

        public Racer GetOldestRacer()
        {
            return Racers.OrderByDescending(n => n.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return Racers.FirstOrDefault(n => n.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return Racers.OrderByDescending(n => n.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            //Racers participating at { RaceName}:
            //{ Racer1}
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            sb.AppendLine(string.Join(Environment.NewLine, Racers));
            return sb.ToString().TrimEnd();
        }
    }
}
