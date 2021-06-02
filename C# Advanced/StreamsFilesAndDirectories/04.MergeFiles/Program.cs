using System;
using System.IO;
using System.Linq;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line1 = File.ReadAllLines("../../../FileOne.txt");
            string[] line2 = File.ReadAllLines("../../../FileTwo.txt");

            File.WriteAllLines("../../../output.txt", line1);
            File.AppendAllLines("../../../output.txt", line2);
            string[] allLines = File.ReadAllLines("../../../output.txt");
            allLines=allLines.OrderBy(x=>x).ToArray();

            File.WriteAllLines("../../../output.txt", allLines);
        }
    }
}
