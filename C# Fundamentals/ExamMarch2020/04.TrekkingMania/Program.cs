using System;

namespace _04.TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            //•	Група до 5 човека– Мусала
            //•	Група от 6 до 12 – Монблан
            //•	Група от 13 до 25 – Килиманджаро
            //•	Група от 26 до 40 – К2
            //•	Група от 41 или повече – Еверест

            int peopleForMusala = 0;
            int peopleForMonblan = 0;
            int peopleForKilimandzaro = 0;
            int peopleForK2 = 0;
            int peopleForEverest = 0;
            for (int i = 1; i <= groups; i++)
            {
                int membersOfGroup = int.Parse(Console.ReadLine());
                if (membersOfGroup <= 5)
                {
                    peopleForMusala += membersOfGroup;
                }
                else if (membersOfGroup >= 6 && membersOfGroup <= 12)
                {
                    peopleForMonblan += membersOfGroup;
                }
                else if (membersOfGroup >= 13 && membersOfGroup <= 25)
                {
                    peopleForKilimandzaro += membersOfGroup;
                }
                else if (membersOfGroup >= 26 && membersOfGroup <= 40)
                {
                    peopleForK2 += membersOfGroup;
                }
                else if (membersOfGroup >= 41)
                {
                    peopleForEverest += membersOfGroup;
                }
            }
            int allPeople = peopleForMusala + peopleForMonblan + peopleForKilimandzaro + peopleForK2 + peopleForEverest;
            double pMusala = 1.0*peopleForMusala / allPeople * 100;
            double pMonblan = 1.0 * peopleForMonblan / allPeople * 100;
            double pKilimandzaro = 1.0 * peopleForKilimandzaro / allPeople * 100;
            double pK2 = 1.0 * peopleForK2 / allPeople * 100;
            double pEverest = 1.0 * peopleForEverest / allPeople * 100;
            Console.WriteLine($"{pMusala:f2}%");
            Console.WriteLine($"{pMonblan:f2}%");
            Console.WriteLine($"{pKilimandzaro:f2}%");
            Console.WriteLine($"{pK2:f2}%");
            Console.WriteLine($"{pEverest:f2}%");
        }
    }
}
