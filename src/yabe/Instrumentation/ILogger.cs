﻿namespace Instrumentation
{
    public interface ILogger
    {
        void LogMessage(string format, params object[] args);
    }
}