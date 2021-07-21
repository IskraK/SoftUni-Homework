using LoggerLibrary.Interfaces;

namespace LoggerLibrary.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Template => "{0} - {1} - {2}";
    }
}
