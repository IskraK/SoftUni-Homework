using LoggerLibrary.Core;

namespace LoggerLibrary
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
