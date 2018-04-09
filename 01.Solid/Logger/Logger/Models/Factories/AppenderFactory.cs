using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Factories
{
    public class AppenderFactory
    {
        const string DefaultFileName= "logFile{0}.txt";

        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 0;
        }

        public IAppender CreteAppender(string appenderType, string levelString, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreatLayout(layoutType);
            ErrorLevel errorLevel = this.ParseLevel(levelString);

            IAppender appender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, errorLevel);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName, this.fileNumber));
                    appender = new FileAppender(layout, errorLevel, logFile);
                    break;
                default:
                    throw new ArgumentException("Invalid ErrorLevel Type!");
            }

            return appender;
        }

        private ErrorLevel ParseLevel(string levelString)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), levelString);
                return (ErrorLevel)levelObj;
            }
            catch (ArgumentException e) // този exception го вкарваме в долния!!!!!!!!!!!
            {
                throw new ArgumentException("Invalid ErrorLevel Type!", e);
                //e.InnerException.......
            }

        }
    }
}
