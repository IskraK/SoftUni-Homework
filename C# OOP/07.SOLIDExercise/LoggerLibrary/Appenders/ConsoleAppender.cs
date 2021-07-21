using LoggerLibrary.Enumerations;
using LoggerLibrary.Interfaces;
using System;

namespace LoggerLibrary.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {
               
        }

        
        public override void Append(string date, ReportLevelEnum reportLevel, string message)
        {
            if (reportLevel < this.ReportLevel)
            {
                return;
            }

            this.MessageCount++;
            string content = string.Format(Layout.Template, date, reportLevel, message);
            Console.WriteLine(content);
        }
    }
}
