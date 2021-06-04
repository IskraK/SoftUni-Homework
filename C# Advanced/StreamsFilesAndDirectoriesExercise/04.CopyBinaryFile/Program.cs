using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            const int DEFSIZE = 4096;

            using FileStream reader = new FileStream("copyMe.png", FileMode.Open);
            byte[] buffer = new byte[DEFSIZE];
            using FileStream writer = new FileStream("../../../copied.png", FileMode.Create);

            while (reader.CanRead)
            {
                int bytesRead = reader.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                {
                    break;
                }

                writer.Write(buffer, 0, buffer.Length);
            }

        }
    }
}
