using System;
using System.IO;

namespace PlayersAndMonsters.IO.Contracts
{
    public class FileWriter : IWriter
    {
        private FileStream fs;
        private StreamWriter sw;

        public FileWriter()
        {
            this.fs = new FileStream("../../../result", FileMode.OpenOrCreate, FileAccess.Write);
            this.sw = new StreamWriter(fs);
            sw.AutoFlush = true;
            Console.SetOut(sw);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        // FileWriter doesn't work correct!!!
    }
}
