using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            // Open VS as Admin
            //Create folders D:\SoftUni\TestFolder

            ZipFile.CreateFromDirectory("../../../../Resources", @"D:\SoftUni\TestFolder\testArchive.zip");
            ZipFile.ExtractToDirectory(@"D:\SoftUni\TestFolder\testArchive.zip", "../../../");
        }
    }
}
