using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Tools.Utilities.Exceptions
{
    public class BusinessExceptionEXCS : BaseExceptions
    {
        /// <summary>
        /// Parameterless Constructor
        /// </summary>
        public BusinessExceptionEXCS()
        {}
        /// <summary>
        /// business Exception Messege Setting Configuration
        /// </summary>
        /// <param name="message"></param>
        public BusinessExceptionEXCS(string message)
            :base(message)
        {

        }
        /// <summary>
        /// This parametrized constructor inherits overloaded constructor with error message as input
        /// </summary>
        public BusinessExceptionEXCS(string responseType, string errCode) : base(responseType, errCode) { }

        /// <summary>
        /// This parametrized constructor inherits overloaded constructor with error message, error code, description as input
        /// </summary>
        public BusinessExceptionEXCS(string message, string errorCode, string description) : base(message, errorCode, description) { }

        /// <summary>
        /// This parametrized constructor inherits overloaded constructor with error message, exception as input
        /// </summary>
        public BusinessExceptionEXCS(string message, Exception ex) : base(message, ex) { }
    }
}
