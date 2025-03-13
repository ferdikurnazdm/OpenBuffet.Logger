using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBuffet.Logger.Core.Types {
    /// <summary>
    /// this enumarations represent the
    /// log types
    /// </summary>
    public enum LogType {
        /// <summary>
        /// this is log none type
        /// for ambiguous logs
        /// </summary>
        NONE = 0,
        /// <summary>
        /// this is log success type
        /// for success logs
        /// </summary>
        SUCCESS = 1,
        /// <summary>
        /// this is log error type
        /// for error logs
        /// </summary>
        ERROR = 2,
        /// <summary>
        /// this is log warning type
        /// for warning logs
        /// </summary>
        WARNING = 3,
        /// <summary>
        /// this is log information type
        /// for information logs
        /// </summary>
        INFO = 4
    }
}
