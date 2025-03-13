using OpenBuffet.Logger.Core.Interfaces;
using OpenBuffet.Logger.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBuffet.Logger.Core.Managers {
    /// <summary>
    /// this class manage the logger services
    /// </summary>
    public sealed class LoggerManager {
        /// <summary>
        /// this field keeps the logger configurator
        /// </summary>
        private readonly IEnumerable<ILoggerService> _loggerServices;

        /// <summary>
        /// this constructor set the logger configurator
        /// </summary>
        /// <param name="loggerServices">logger services</param>
        public LoggerManager(IEnumerable<ILoggerService> loggerServices) {
            _loggerServices = loggerServices;
        }




        /// <summary>
        /// this method logging the given content
        /// </summary>
        /// <param name="logType">log type</param>
        /// <param name="content">log content</param>
        /// <param name="exception">return null if method runned succesfully 
        /// otherwise return occured exception</param>
        /// <returns>return true if method runned succesfully otherwise return false</returns>
        public bool TryLogging(LogType logType, string content, out Exception exception) {
            bool result = false;
            exception = null;
            try {
                foreach (var logger in _loggerServices) {
                    if (!logger.TryLogging(logType, content, out exception)) {
                        return false;
                    }
                }
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
        /// this method clean the logs
        /// </summary>
        /// <param name="exception">return null if method runned succesfully 
        /// otherwise return occured exception</param>
        /// <returns>return true if method runned succesfully otherwise return false</returns>
        public bool TryCleanLogs(out Exception exception) {
            bool result = false;
            exception = null;
            try {
                foreach (var logger in _loggerServices) {
                    if (!logger.TryCleanLogs(out exception)) {
                        return false;
                    }
                }
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
