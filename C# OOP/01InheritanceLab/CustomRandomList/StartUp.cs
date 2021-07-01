using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list2 = new RandomList();
            Console.WriteLine(list2.RandomString());

            RandomList list = new RandomList();
            list.Add("Person1");
            list.Add("Person2");
            list.Add("Person3");
            list.Add("Person4");
            list.Add("Person5");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list.RandomString());
            }
        }
    }
}
