using Logger.Models.Contracts;
using Logger.Models.Factories;
using System;

namespace Logger
{
   public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] errorArgs = input.Split('|');
                    string level = errorArgs[0];
                    string dateTime = errorArgs[1];
                    string message = errorArgs[2];

                    IError error = errorFactory.CreateError(dateTime, level, message);
                    logger.Log(error);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Logger info");
            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
