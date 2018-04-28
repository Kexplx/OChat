using System;
using System.IO;
using System.Threading;

namespace OChatNew.Core.Utilities.Logging
{
    /// <summary>
    /// Thread safe logger
    /// </summary>
    public class OLogger
    {
        private readonly string _path;
        private object _lock = new object();

        public bool LogToConsoleEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes the logger and appends to the file under <paramref name="path"/>.
        /// If the files doesn't exist it will be created
        /// </summary>
        /// <param name="path">The path of the created LogFile</param>
        public OLogger(string path, bool logToConsoleEnabled = false)
        {
            LogToConsoleEnabled = logToConsoleEnabled;
            _path = path;

            using (var stream = File.Open(path, FileMode.OpenOrCreate)) { }
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.INFO"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation Info(string message, Type loggedFromThisClassType)
        {
            Monitor.Enter(_lock);
            var logInformation = new LogInformation
            {
                Message = DateTime.Now.ToString() + " INFO " + loggedFromThisClassType.FullName + " - " + message,
                Type = LogMessageType.INFO
            };

            File.AppendAllText(_path, logInformation.Message + Environment.NewLine);
            WriteToConsole(logInformation);

            Monitor.Exit(_lock);
            return logInformation;
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.ERROR"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation Error(string message, Type loggedFromThisClassType)
        {
            Monitor.Enter(_lock);

            var logInformation = new LogInformation
            {
                Message = DateTime.Now.ToString() + " ERROR " + loggedFromThisClassType.FullName + " - " + message,
                Type = LogMessageType.ERROR
            };

            File.AppendAllText(_path, logInformation.Message + Environment.NewLine);
            WriteToConsole(logInformation);

            Monitor.Exit(_lock);
            return logInformation;
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.WARNING"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation Warn(string message, Type loggedFromThisClassType)
        {
            Monitor.Enter(_lock);
            var logInformation = new LogInformation
            {
                Message = DateTime.Now.ToString() + " WARNING " + loggedFromThisClassType.FullName + " - " + message,
                Type = LogMessageType.WARNING
            };

            File.AppendAllText(_path, logInformation.Message + Environment.NewLine);
            WriteToConsole(logInformation);

            Monitor.Exit(_lock);
            return logInformation;
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.FATAL"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation Fatal(string message, Type loggedFromThisClassType)
        {
            Monitor.Enter(_lock);
            var logInformation = new LogInformation
            {
                Message = DateTime.Now.ToString() + " FATAL " + loggedFromThisClassType.FullName + " - " + message,
                Type = LogMessageType.FATAL
            };

            File.AppendAllText(_path, logInformation.Message + Environment.NewLine);
            WriteToConsole(logInformation);

            Monitor.Exit(_lock);
            return logInformation;
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.FINALINFO"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation FinalInfo(string message, Type loggedFromThisClassType)
        {
            Monitor.Enter(_lock);
            var logInformation = new LogInformation
            {
                Message = DateTime.Now.ToString() + " FINALINFO " + loggedFromThisClassType.FullName + " - " + message,
                Type = LogMessageType.FINALINFO
            };

            File.AppendAllText(_path, logInformation.Message + Environment.NewLine);
            WriteToConsole(logInformation);

            Monitor.Exit(_lock);
            return logInformation;
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.CANCELINFO"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation CancelInfo(string message, Type loggedFromThisClassType)
        {
            Monitor.Enter(_lock);
            var logInformation = new LogInformation
            {
                Message = DateTime.Now.ToString() + " CANCELINFO " + loggedFromThisClassType.FullName + " - " + message,
                Type = LogMessageType.CANCELINFO
            };

            File.AppendAllText(_path, logInformation.Message + Environment.NewLine);
            WriteToConsole(logInformation);

            Monitor.Exit(_lock);
            return logInformation;
        }

        /// <summary>
        /// Outputs the message to the console, with the specified foreground
        /// </summary>
        /// <param name="message"></param>
        public void WriteToConsole(LogInformation message)
        {
            if (!LogToConsoleEnabled)
            {
                return;
            }

            switch (message.Type)
            {
                case LogMessageType.INFO:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(message.Message);
                    Console.ResetColor();
                    break;

                case LogMessageType.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message.Message);
                    Console.ResetColor();
                    break;

                case LogMessageType.WARNING:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(message.Message);
                    Console.ResetColor();
                    break;

                default:
                    Console.WriteLine(message.Message);
                    break;
            }
        }
    }
}