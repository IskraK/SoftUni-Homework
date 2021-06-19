using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private readonly T[] stones;
        public Lake(params T[] stones)
        {
            this.stones = stones;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i+=2)
            {
                yield return stones[i];
            }

            for (int i = stones.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
