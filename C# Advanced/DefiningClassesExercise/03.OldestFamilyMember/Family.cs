using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {

        List<Person> FamilyMembers = new List<Person>();

        public void AddMember(Person member)
        {
            FamilyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = FamilyMembers.FirstOrDefault();
            foreach (var member in FamilyMembers)
            {
                if (member.Age > oldestMember.Age)
                {
                    oldestMember.Age = member.Age;
                    oldestMember.Name = member.Name;
                }
            }
            return oldestMember;
        }
    }
}
