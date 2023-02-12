namespace _01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Console.WriteLine(Sum(arr));
        }

        static int Sum(int[] array, int index = 0)
        {
            if (index == array.Length - 1)
            {
                return array[index];
            }

            return array[index] + Sum(array, index + 1);
        }
    }
}