namespace _07.MilitaryElite.Models
{
    using _07.MilitaryElite.Iterfaces;

    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary,string corp) 
            : base(id, firstName, lastName, salary)
        {
            Corp = corp;
        }

        public string Corp { get; private set; }
    }
}
