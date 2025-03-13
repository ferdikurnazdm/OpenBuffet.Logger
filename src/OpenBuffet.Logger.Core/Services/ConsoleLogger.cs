using OpenBuffet.Logger.Core.Interfaces;
using OpenBuffet.Logger.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBuffet.Logger.Core.Services {
    /// <summary>
    /// this class manage the console log
    /// </summary>
    public sealed class ConsoleLogger : ILoggerService {
        /// <summary>
        /// this method clean the console logs
        /// </summary>
        /// <param name="exception">return null if method runned succesfully 
        /// otherwise return occured exception</param>
        /// <returns>return true if method runned succesfully otherwise return false</returns>
        public bool TryCleanLogs(out Exception exception) {
            bool result = false;
            exception = null;
            try {
                Console.Clear();
                result = true;
            }
            catch (Exception ex) {
                exception = ex;
                exception.Source = this.GetType().FullName;
                result = false;
            }
            return result;
        }
        /// <summary>
        /// this method logging to console by log type
        /// </summary>
        /// <param name="logType">log type</param>
        /// <param name="content">log content</param>
        /// <param name="exception">return null if method runned succesfully 
        /// otherwise return occured exception</param>
        /// <returns>return true if method runned succesfully otherwise return false</returns>
        public bool TryLogging(LogType logType, string content, out Exception exception) {
            if (string.IsNullOrWhiteSpace(content)) {
                exception = new ArgumentNullException($"{nameof(content)} is null or white space");
                return false;
            }
            bool result = false;
            exception = null;
            try {
                Console.WriteLine($"{logType} | {DateTime.Now} | {content}");
                result = true;
            }
            catch (Exception ex) {
                exception = ex;
                exception.Source = this.GetType().FullName;
                result = false;
            }
            return result;
        }
    }
}
