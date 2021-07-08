namespace _07.MilitaryElite.Models
{
    using _07.MilitaryElite.Iterfaces;

    public abstract class Soldier : ISoldier
    {
        protected Soldier(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get ; private set ; }
        public string FirstName { get ; private set ; }
        public string LastName { get ; private set ; }
    }
}
