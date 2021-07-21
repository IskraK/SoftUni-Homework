using LoggerLibrary.Enumerations;
using LoggerLibrary.Interfaces;

namespace LoggerLibrary.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile logFile;
        public FileAppender(ILayout layout, ILogFile logFile)
            :base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevelEnum reportLevel, string message)
        {
            if (reportLevel < this.ReportLevel)
            {
                return;
            }

            this.MessageCount++;
            string content = string.Format(this.Layout.Template, date, reportLevel, message);
            this.logFile.Write(content);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, File size: {this.logFile.Size}";
        }
    }
}
