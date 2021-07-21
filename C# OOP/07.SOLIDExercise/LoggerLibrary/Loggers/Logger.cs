using LoggerLibrary.Enumerations;
using LoggerLibrary.Interfaces;
using System.Text;

namespace LoggerLibrary.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;   
        }
        

        public void Info(string date, string message)
        {
            AppendMessage(date, ReportLevelEnum.Info, message);
        }

        public void Warning(string date, string message)
        {
            AppendMessage(date, ReportLevelEnum.Warning, message);
        }

        public void Error(string date, string message)
        {
            AppendMessage(date, ReportLevelEnum.Error, message);
        }

        public void Critical(string date, string message)
        {
            AppendMessage(date, ReportLevelEnum.Critical, message);
        }

        public void Fatal(string date, string message)
        {
            AppendMessage(date, ReportLevelEnum.Fatal, message);
        }

        private void AppendMessage(string date, ReportLevelEnum reportLevel,string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                appender.Append(date, reportLevel, message);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");

            foreach (IAppender appender in this.appenders)
            {
                sb.AppendLine(appender.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
