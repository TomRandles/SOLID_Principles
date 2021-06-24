using RatingApp.Core.Interfaces;
using System;

namespace RatingApp.Infrastructure.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void LogInformation(string logMessage)
        {
            Console.Write(logMessage);
        }
    }
}