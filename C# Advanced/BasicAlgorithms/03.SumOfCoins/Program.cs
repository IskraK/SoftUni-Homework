namespace _03.SumOfCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////According the task
            //var tokens = Console.ReadLine()
            //    .Split(": ", StringSplitOptions.RemoveEmptyEntries);
            //var availableCoins = tokens[1]
            //    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .OrderByDescending(x => x)
            //    .ToArray();
            //var targetSum = Console.ReadLine()
            //    .Split(": ")
            //    .Skip(1)
            //    .Select(int.Parse)
            //    .ToArray()[0];

            ////According Judge input
            var availableCoins = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .ToArray();
            var targetSum = int.Parse(Console.ReadLine());

            var selectedCoins = new Dictionary<int, int>();

            try
            {
                selectedCoins = ChooseCoins(availableCoins, targetSum);

                Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
                foreach (var selectedCoin in selectedCoins)
                {
                    Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }

        ////Very slow (~5s) when input is:
        ////Coins: 1, 2, 5
        ////Sum: 2031154123
        //public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        //{
        //    int sum = 0;
        //    Dictionary<int, int> result = new Dictionary<int, int>();

        //    for (int i = 0; i < coins.Count; i++)
        //    {
        //        while (coins[i] + sum <= targetSum)
        //        {
        //            sum += coins[i];
        //            if (!result.ContainsKey(coins[i]))
        //            {
        //                result.Add(coins[i], 0);
        //            }

        //            result[coins[i]]++;
        //        }
        //    }

        //    if (sum == targetSum)
        //    {
        //        return result;
        //    }

        //    throw new Exception();
        //}

        //Another decision - faster (~0.1s)
        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            int sum = 0;
            int currentTarget = targetSum;
            Dictionary<int, int> result = new Dictionary<int, int>();

            for (int i = 0; i < coins.Count; i++)
            {
                int count = currentTarget / coins[i];
                if (count > 0)
                {
                    result.Add(coins[i], count);
                    sum += coins[i] * count;
                    currentTarget -= coins[i] * count;
                }
            }

            if (sum == targetSum)
            {
                return result;
            }

            throw new Exception();
        }
    }
}