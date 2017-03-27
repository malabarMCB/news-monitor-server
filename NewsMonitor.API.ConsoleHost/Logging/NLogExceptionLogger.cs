using System;
using System.Web.Http.ExceptionHandling;
using NLog;

namespace NewsMonitor.API.ConsoleHost.Logging
{
    public class NLogExceptionLogger : ExceptionLogger
    {
        private readonly ILogger _logger;

        public NLogExceptionLogger() 
            : this(LogManager.GetCurrentClassLogger())
        {
        }

        public NLogExceptionLogger(ILogger logger)
        {
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            _logger = logger;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            var logEvent = new LogEventInfo
            {
                Level = LogLevel.Error,
                TimeStamp = DateTime.UtcNow,
                Message = context.Exception?.Message
            };

            ImportProperties(logEvent, context);
            _logger.Log(logEvent);
        }

        private static void ImportProperties(LogEventInfo logEvent, ExceptionLoggerContext context)
        {
            // Request context
            logEvent.Properties["Request_Method"] = context.Request.Method?.Method;
            logEvent.Properties["Request_Uri"] = context.Request.RequestUri?.AbsolutePath;
            logEvent.Properties["Request_Content"] = context.Request.Content?.ReadAsStringAsync().Result;

            // Controller context
            logEvent.Properties["Controller_Name"] =
                context.ExceptionContext?.ControllerContext?.ControllerDescriptor?.ControllerName;
            logEvent.Properties["Controller_Type"] =
                context.ExceptionContext?.ControllerContext?.ControllerDescriptor?.ControllerType?.Name;

            logEvent.Exception = context.Exception;
        }
    }
}