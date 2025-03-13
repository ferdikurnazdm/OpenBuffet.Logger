using OpenBuffet.Logger.Core.Configurator;
using OpenBuffet.Logger.Core.Interfaces;
using OpenBuffet.Logger.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBuffet.Logger.Core.Services {
    /// <summary>
    /// this class manage the text logger process
    /// </summary>
    public sealed class TextLogger : ILoggerService {
        /// <summary>
        /// this field keeps the file type extention
        /// </summary>
        private const string FILE_TYPE = ".txt";
        /// <summary>
        /// this field keeps the log date format
        /// </summary>
        private const string DATE_FORMAT = "yyyy-MM-dd";
        /// <summary>
        /// this field keeps string builder
        /// </summary>
        private readonly StringBuilder _stringBuilder;
        /// <summary>
        /// this field keeps the text configurator object
        /// </summary>
        private readonly TextLoggerConfigurator _textConfigurator;
        /// <summary>
        /// this field keeps the log file directory
        /// </summary>
        private readonly string _logFileDirectory;



        /// <summary>
        /// this constructor set the text configurator
        /// log file directory(add the "Logs" folder togiven path givenPath/Logs)
        /// and set the string builder
        /// </summary>
        /// <param name="configurator">text configurator</param>
        public TextLogger(TextLoggerConfigurator configurator) {
            _textConfigurator = configurator;
            _logFileDirectory = Path.Combine(_textConfigurator.Path, "Logs");
            _stringBuilder = new StringBuilder();
        }

        /// <summary>
        /// this method clean the all logs
        /// </summary>
        /// <param name="exception">return null if method runned succesfully 
        /// otherwise return occured exception</param>
        /// <returns>return true if method runned succesfully otherwise return false</returns>
        public bool TryCleanLogs(out Exception exception) {
            bool result = false;
            exception = null;
            try {
                if (!Directory.Exists(_logFileDirectory)) {
                    exception = new InvalidOperationException("path not found");
                    return false;
                }
                Directory.Delete(_logFileDirectory, true);
                result = true;
            }
            catch (Exception ex) {
                exception = ex;
                exception.Source = this.GetType().Name;
                result = false;
            }
            return result;
        }

        /// <summary>
        /// this method logs the content by logtype and date
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
                bool isContentBad = string.IsNullOrWhiteSpace(content);
                if (isContentBad) {
                    exception = new ArgumentNullException($"{content} is empty or white space");
                    return false;
                }
                string logFileNameAsDate = GetDestinationFileNameByDate();
                string logFileLocation = Path.Combine(_logFileDirectory, logFileNameAsDate);
                string preparedLog = $"{logType.ToString()} | {DateTime.Now.ToString()} | {content}\r\n";
                if (!Directory.Exists(_logFileDirectory)) {
                    Directory.CreateDirectory(_logFileDirectory);
                }
                File.AppendAllText(logFileLocation, preparedLog);
                result = true;
            }
            catch (Exception ex) {
                exception = ex;
                exception.Source = this.GetType().Name;
                result = false;
            }
            return result;
        }
        /// <summary>
        /// this method prepare the destination file 
        /// name as date by date format
        /// </summary>
        /// <returns></returns>
        private string GetDestinationFileNameByDate() {
            _stringBuilder.Clear();
            string fileNameByDate = _stringBuilder
                .Append(DateTime.Today.ToString(DATE_FORMAT))
                .Append(FILE_TYPE)
                .ToString();
            return fileNameByDate;
        }

    }
}
