using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../TestFolder");
            double fileSize = 0;

            foreach (var filePath in files)
            {
                FileInfo file = new FileInfo(filePath);
                fileSize += file.Length;
            }

            fileSize = fileSize / 1024.0 / 1024.0;
            Console.WriteLine(fileSize);
            File.WriteAllText("../../../output.txt", fileSize.ToString());
        }
    }
}
