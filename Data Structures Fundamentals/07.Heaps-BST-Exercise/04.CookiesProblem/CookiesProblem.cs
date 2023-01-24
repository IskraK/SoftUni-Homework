using _03.MinHeap;
using System;
using System.Linq;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            var bag = new OrderedBag<int>(cookies);
            var smallestElement = bag.GetFirst();
            var steps = 0;

            while (smallestElement < k && bag.Count >= 2)
            {
                var smallestCookie = bag.RemoveFirst();
                var secondSmallestCookie = bag.RemoveFirst();

                steps++;
                bag.Add(smallestCookie + 2 * secondSmallestCookie);
                smallestElement = bag.GetFirst();
            }

            return smallestElement >= k ? steps : -1;
        }

        ////Decision with MinHeap
        //public int Solve(int k, int[] cookies)
        //{
        //    var bag = new MinHeap<int>();
        //    cookies.ToList().ForEach(x => bag.Add(x));

        //    var smallestElement = bag.Peek();
        //    var steps = 0;

        //    while (smallestElement < k && bag.Size >= 2)
        //    {
        //        var smallestCookie = bag.Dequeue();
        //        var secondSmallestCookie = bag.Dequeue();

        //        steps++;
        //        bag.Add(smallestCookie + 2 * secondSmallestCookie);
        //        smallestElement = bag.Peek();
        //    }

        //    return smallestElement >= k ? steps : -1;
        //}
    }
}
