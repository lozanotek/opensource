namespace Web.Utilities
{
    using System;
    using System.IO;
    using log4net.Config;

    public class LoggingUtility
    {
        public static void Initialize()
        {
            string basePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string path = Path.Combine(basePath, "log4net.config");

            XmlConfigurator.ConfigureAndWatch(new FileInfo(path));
        }
    }
}