using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBuffet.Logger.Core.Configurator {
    /// this class manage the jsonl 
    /// logger configure process
    /// </summary>
    public sealed class JsonlLoggerConfigurator {
        /// <summary>
        /// this field keeps the log file path
        /// </summary>
        private string _path = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// this property keeps the log file path
        /// </summary>
        public string Path {
            get { return _path; }
            set { _path = value; }
        }
    }
}
