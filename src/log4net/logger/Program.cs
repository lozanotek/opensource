namespace logger
{
    using System;
    using System.IO;
    using log4net;
    using log4net.Config;

    internal class Program
    {
        private static void Main(string[] args)
        {
            ConfigureLog4Net();

            ILog log = LogManager.GetLogger(typeof (Program));

            DoSomeLogging(log);

            ILog namedLogger = LogManager.GetLogger("DemoLogger");
            DoSomeLogging(namedLogger);

            Console.Write("Press <ENTER> to exit...");
            Console.ReadLine();
        }

        private static void ConfigureLog4Net()
        {
            string basePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string path = Path.Combine(basePath, "log4net.config");

            XmlConfigurator.ConfigureAndWatch(new FileInfo(path));
        }

        private static void DoSomeLogging(ILog log)
        {
            if (log.IsDebugEnabled)
            {
                log.Debug("This is a debug message");
            }

            if (log.IsInfoEnabled)
            {
                log.Info("This is an info message");
            }

            if (log.IsWarnEnabled)
            {
                log.Warn("This is a warning message");
            }

            if (log.IsErrorEnabled)
            {
                log.Error("This is an error message", new Exception("Oh noes!"));
            }

            if (log.IsFatalEnabled)
            {
                log.Fatal("This is a fatal message", new Exception("EPIC FAIL!"));
            }
        }
    }
}