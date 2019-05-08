using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Logging.Log4Net
{
	/// <summary>
	/// Logger writing entries using NLog.
	/// </summary>
	public class Log4NetLogger : ILogger
	{
		#region Private fields

		private readonly log4net.ILog log;

		#endregion

		#region Construction

		internal Log4NetLogger(log4net.ILog log)
		{
			if (log == null) throw new ArgumentNullException(nameof(log));

			this.log = log;
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Write an entry to the registered log appenders.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="message">
		/// The message for the log entry, optionally in a <see cref="String.Format(string, object[])"/>
		/// form when there are <paramref name="arguments"/>.</param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.
		/// </param>
		/// <remarks>
		/// Both <see cref="LogLevel.Debug"/> and <see cref="LogLevel.Trace"/> levels are fed
		/// to <see cref="log4net.ILog.DebugFormat(string, object[])"/>.
		/// </remarks>
		public void Log(LogLevel logLevel, string message, params object[] arguments)
		{
			string formattedMessage = String.Format(message, arguments);

			log4net.Core.Level log4netLevel = TranslateToLog4netLevel(logLevel);

			log.Logger.Log(GetType(), log4netLevel, formattedMessage, null);
		}

		/// <summary>
		/// Write an entry to the registered log appenders.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="exception">The exception to record in the log entry.</param>
		/// <param name="message">
		/// The message for the log entry, optionally in a <see cref="String.Format(string, object[])"/>
		/// form when there are <paramref name="arguments"/>.
		/// </param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.</param>
		/// <remarks>
		/// Both <see cref="LogLevel.Debug"/> and <see cref="LogLevel.Trace"/> levels are fed
		/// to <see cref="log4net.ILog.Debug(object, Exception)"/>.
		/// </remarks>
		public void Log(LogLevel logLevel, Exception exception, string message, params object[] arguments)
		{
			string formattedMessage = String.Format(message, arguments);

			log4net.Core.Level log4netLevel = TranslateToLog4netLevel(logLevel);

			log.Logger.Log(GetType(), log4netLevel, formattedMessage, exception);
		}

		/// <summary>
		/// Write an entry to the registered log appenders.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="formatProvider">The formatter to use for the <paramref name="message"/>.</param>
		/// <param name="message">
		/// The message for the log entry, in a <see cref="String.Format(IFormatProvider, string, object[])"/> form.
		/// </param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.</param>
		/// <remarks>
		/// Both <see cref="LogLevel.Debug"/> and <see cref="LogLevel.Trace"/> levels are fed
		/// to <see cref="log4net.ILog.DebugFormat(IFormatProvider, string, object[])"/>.
		/// </remarks>
		public void Log(LogLevel logLevel, IFormatProvider formatProvider, string message, params object[] arguments)
		{
			string formattedMessage = String.Format(formatProvider, message, arguments);

			log4net.Core.Level log4netLevel = TranslateToLog4netLevel(logLevel);

			log.Logger.Log(GetType(), log4netLevel, formattedMessage, null);
		}

		/// <summary>
		/// Write an entry to the registered log appenders.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="exception">The exception to record in the log entry.</param>
		/// <param name="formatProvider">The formatter to use for the <paramref name="message"/>.</param>
		/// <param name="message">
		/// The message for the log entry, in a <see cref="String.Format(IFormatProvider, string, object[])"/> form.
		/// </param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.</param>
		/// <remarks>
		/// Both <see cref="LogLevel.Debug"/> and <see cref="LogLevel.Trace"/> levels are fed
		/// to <see cref="log4net.ILog.Debug(object, Exception)"/>.
		/// </remarks>
		public void Log(LogLevel logLevel, Exception exception, IFormatProvider formatProvider, string message, params object[] arguments)
		{
			string formattedMessage = String.Format(formatProvider, message, arguments);

			log4net.Core.Level log4netLevel = TranslateToLog4netLevel(logLevel);

			log.Logger.Log(GetType(), log4netLevel, formattedMessage, exception);
		}

		#endregion

		#region Private methods

		/// <summary>
		/// Translate log level to log4net.
		/// </summary>
		private static log4net.Core.Level TranslateToLog4netLevel(LogLevel logLevel)
		{
			switch (logLevel)
			{
				case LogLevel.Trace:
					return log4net.Core.Level.Trace;

				case LogLevel.Debug:
					return log4net.Core.Level.Debug;

				case LogLevel.Warn:
					return log4net.Core.Level.Warn;

				case LogLevel.Error:
					return log4net.Core.Level.Error;

				case LogLevel.Fatal:
					return log4net.Core.Level.Fatal;

				default:
					return log4net.Core.Level.Info;
			}
		}

		#endregion
	}
}
