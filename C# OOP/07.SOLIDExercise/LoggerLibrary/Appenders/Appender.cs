using LoggerLibrary.Enumerations;
using LoggerLibrary.Interfaces;


namespace LoggerLibrary.Appenders
{
    public abstract class Appender : IAppender
    {
        public ILayout Layout { get; }
        public ReportLevelEnum ReportLevel { get ; set ; }
        public int MessageCount { get; protected set; }

        protected Appender(ILayout layout)
        {
            Layout = layout;
        }

        public abstract void Append(string date, ReportLevelEnum reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessageCount}";
        }

    }
}
