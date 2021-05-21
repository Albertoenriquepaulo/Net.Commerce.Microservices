using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Common.Logging
{

    // Extracted from https://gunnarpeipman.com/aspnet-core-syslog/
    public class SysLogger : ILogger
    {
        private const int SyslogFacility = 16;

        private readonly string _categoryName;
        private readonly string _host;
        private readonly int _port;

        private readonly Func<string, LogLevel, bool> _filter;

        public SysLogger(string categoryName,
                            string host,
                            int port,
                            Func<string, LogLevel, bool> filter)
        {
            _categoryName = categoryName;
            _host = host;
            _port = port;

            _filter = filter;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NoopDisposable.Instance;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return (_filter == null || _filter(_categoryName, logLevel));
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            message = $"{ logLevel }: {message}";

            if (exception != null)
            {
                message += Environment.NewLine + Environment.NewLine + exception.ToString();
            }

            var syslogLevel = MapToSyslogLevel(logLevel);
            Send(syslogLevel, message);
        }

        internal void Send(SyslogLogLevel logLevel, string message)
        {
            if (string.IsNullOrWhiteSpace(_host) || _port <= 0)
            {
                return;
            }

            var hostName = Dns.GetHostName();
            var level = SyslogFacility * 8 + (int)logLevel;
            var logMessage = $"<{level}>{hostName} {message}";
            var bytes = Encoding.UTF8.GetBytes(logMessage);

            using var client = new UdpClient();
            client.SendAsync(bytes, bytes.Length, _host, _port).Wait();
        }

        private SyslogLogLevel MapToSyslogLevel(LogLevel level)
        {
            return level switch
            {
                LogLevel.Critical => SyslogLogLevel.Critical,
                LogLevel.Debug => SyslogLogLevel.Debug,
                LogLevel.Error => SyslogLogLevel.Error,
                LogLevel.Information => SyslogLogLevel.Info,
                LogLevel.None => SyslogLogLevel.Info,
                LogLevel.Trace => SyslogLogLevel.Info,
                LogLevel.Warning => SyslogLogLevel.Warn,
                _ => SyslogLogLevel.Info
            };
        }
    }

    public enum SyslogLogLevel
    {
        Emergency,
        Alert,
        Critical,
        Error,
        Warn,
        Notice,
        Info,
        Debug
    }

}
