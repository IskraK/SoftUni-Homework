using LoggerLibrary.Enumerations;

namespace LoggerLibrary.Interfaces
{
    public interface IAppender
    {
        public ReportLevelEnum ReportLevel { get; set; }
        public void Append(string date, ReportLevelEnum reportLevel, string message);
    }
}
