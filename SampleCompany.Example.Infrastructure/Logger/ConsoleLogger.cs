// 
// This is an example of interface based design in action.  The console logger is one implementation of the 
// ILogger interface, so that we can also create different types of loggers and pass them in with no changes.
// The LogEntry class is to store the data, it will be used by all loggers.  To use a 3rd party logger for 
// example, you create a new logger and just implement that inside of a new ILogger.
//

using System;
using Newtonsoft.Json;

namespace SampleCompany.Infrastructure.Logger
{
    public class ConsoleLogger : ILogger
    {
        private readonly LoggingEventType _eventType;

        public ConsoleLogger(LoggingEventType eventType)
        {
            _eventType = eventType;
        }

        public void Log(LogEntry entry)
        {
            Console.WriteLine(JsonConvert.SerializeObject(entry));
        }
    }
}