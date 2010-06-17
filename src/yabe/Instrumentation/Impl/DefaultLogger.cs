namespace Instrumentation
{
    using log4net;

    public class DefaultLogger : ILogger
    {
        private readonly ILog currentLog = LogManager.GetLogger(typeof (DefaultLogger));

        #region ILogger Members

        public void LogMessage(string format, params object[] args)
        {
            if (currentLog.IsInfoEnabled)
            {
                currentLog.InfoFormat(format, args);
            }
        }

        #endregion
    }
}