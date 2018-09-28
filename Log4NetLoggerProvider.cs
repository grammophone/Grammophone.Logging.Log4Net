using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Logging.Log4Net
{
	/// <summary>
	/// Provides a logger based on log4net.
	/// </summary>
	public class Log4NetLoggerProvider : ILoggerProvider
	{
		/// <summary>
		/// Returns a logger based on <see cref="log4net.LogManager.GetLogger(string)"/>.
		/// </summary>
		/// <param name="loggerName">The name of the logger.</param>
		/// <returns>Returns a <see cref="Log4NetLogger"/>.</returns>
		public ILogger CreateLogger(string loggerName)
		{
			var log = log4net.LogManager.GetLogger(loggerName);

			return new Log4NetLogger(log);
		}
	}
}
