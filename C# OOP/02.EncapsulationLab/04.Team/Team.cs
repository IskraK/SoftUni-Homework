using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private readonly List<Person> firstTeam;
        private readonly List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public  IReadOnlyCollection<Person> FirstTeam
        {
            get { return firstTeam; }
        }

        

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return reserveTeam; }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
