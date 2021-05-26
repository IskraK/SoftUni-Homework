using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            List<int> numbers = new List<int>(message.Length);
            List<char> text = new List<char>(message.Length);

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] >= 48 && message[i] <= 57)
                {
                    numbers.Add(int.Parse(message[i].ToString()));
                }
                else
                {
                    text.Add(message[i]);
                }
            }

            List<int> takeList = new List<int>(numbers.Count);
            List<int> skipList = new List<int>(numbers.Count);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            List<string> result = new List<string>();

            int index = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                int offset = takeList[i];

                if (index+offset > text.Count-1)
                {
                    offset = text.Count - index;
                }

                for (int j = index; j < index+offset; j++)
                {
                    result.Add(text[j].ToString());
                }

                index += takeList[i] + skipList[i];
            }

            Console.WriteLine(string.Join("",result));
        }
    }
}
