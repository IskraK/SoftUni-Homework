using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            int lastPointIdx = filePath.LastIndexOf('.');
            int lastLineIdx = filePath.LastIndexOf('\\');
            string fileName = filePath.Substring(lastLineIdx + 1, lastPointIdx - lastLineIdx-1);
            string fileExtension = filePath.Substring(lastPointIdx + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
