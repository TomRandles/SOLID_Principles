using RatingApp.Core.Interfaces;
using System.IO;

namespace RatingApp.Infrastructure.Loggers
{
    public class FileLogger : ILogger
    {
        public void LogInformation(string logMessage)
        {
            using (var stream = File.AppendText("log.txt"))
            {
                stream.WriteLine(logMessage);
                stream.Flush();
            }
        }
    }
}