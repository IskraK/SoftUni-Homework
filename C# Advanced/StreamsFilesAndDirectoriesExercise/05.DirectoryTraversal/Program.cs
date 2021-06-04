using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = @"C:\Windows";
            //string desktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);    ////Access denied !!!
            string newDirectory = "../../../";
            Dictionary<string, Dictionary<string, double>> filesByExtension = new Dictionary<string, Dictionary<string, double>>();
            string[] files = Directory.GetFiles(directory);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string fileName = fileInfo.Name;
                string fileExtension = fileInfo.Extension.ToLower();
                double fileLength = fileInfo.Length;

                if (!filesByExtension.ContainsKey(fileExtension))
                {
                    filesByExtension.Add(fileExtension, new Dictionary<string, double>());
                }
                filesByExtension[fileExtension].Add(fileName, fileLength/1024.0);
            }

            StringBuilder result = new StringBuilder();

            var sortedFilesByExtension = filesByExtension
                .OrderByDescending(n => n.Value.Count)
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var kvp in sortedFilesByExtension)
            {
                string extension = kvp.Key;
                Dictionary<string,double> fileAndLength = kvp.Value.OrderBy(n => n.Value).ToDictionary(x => x.Key,y => y.Value);
                result.AppendLine(extension);

                foreach (var file in fileAndLength)
                {
                    string name = file.Key;
                    double length = file.Value;

                    result.AppendLine($"--{name} - {length:F2}kb");
                }
            }

            File.AppendAllText(Path.Combine(newDirectory, "report.txt"), result.ToString());
        }
    }
}
