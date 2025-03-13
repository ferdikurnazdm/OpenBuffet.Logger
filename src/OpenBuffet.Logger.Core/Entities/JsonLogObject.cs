using OpenBuffet.Logger.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBuffet.Logger.Core.Entities {
    /// <summary>
    /// this class represent the json log object
    /// </summary>
    internal sealed class JsonLogObject {
        /// <summary>
        /// this property keeps the log date
        /// </summary>
        public DateTime LogDate { get; set; }
        /// <summary>
        /// this property keeps the log type
        /// </summary>
        public LogType LogType { get; set; }
        /// <summary>
        /// this property keeps the log content
        /// </summary>
        public string LogContent { get; set; }
    }
}
