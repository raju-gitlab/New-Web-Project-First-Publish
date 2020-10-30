using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Tools.Utilities.Exceptions
{
    /// <summary>
    /// Base Exception Class to be inherited by exception class
    /// </summary>
    [Serializable]
    public class BaseExceptions : Exception
    {
        /// <summary>
        /// Gets And Sets The Error Code for the Exception
        /// </summary>
        private string _errorCode;
        public string errorCode
        {
            get
            {
                return _errorCode;
            }
            set
            {
                _errorCode = value;
            }
        }
        /// <summary>
        /// Get And Sets the errorMessege For The Exception
        /// </summary>
        private string _errorMessege;
        public string errorMessege
        {
            get
            {
                return _errorMessege;
            }
            set
            {
                _errorMessege = value;
            }

        }
        /// <summary>
        /// Get And Sets the Response For The Exception
        /// </summary>
        private string _responseType;
        public string ResponseType
        {
            get
            {
                return _responseType;
            }
            set
            {
                _responseType = value;
            }
        }
        /// <summary>
        /// Gets and Sets the errordescription for the exception
        /// </summary>
        private string _errorDescription;
        public string errorDescription
        {
            get
            {
                return _errorDescription;
            }
            set
            {
                _errorDescription = value;
            }
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseExceptions()
        {}
        /// <summary>
        /// Override default Constructor with String Messege
        /// </summary>
        /// <param name="message"></param>
        public BaseExceptions(string message)
            :base(message)
        {
            _errorMessege = message;
        }
        /// <summary>
        /// Override default Constructor with String Messege,errorcode and description
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        /// <param name="Description"></param>
        public BaseExceptions(string message,string errorCode,string Description)
        {
            _errorMessege = message;
            _errorCode = errorCode;
            _errorDescription = Description;
        }
        /// <summary>
        /// Override default Constructor with String Messege and  ex description(Stack Trace)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public BaseExceptions(string message,Exception ex)
        {
            _errorMessege = message;
            _errorDescription = ex.StackTrace;
        }
        /// <summary>
        /// Override default Constructor with String ResponseType and errorcode
        /// </summary>
        /// <param name="responseType"></param>
        /// <param name="ErrorCode"></param>
        public BaseExceptions(string responseType , string ErrorCode)
        {
            _responseType = responseType;
            _errorCode = ErrorCode;
        }
    }
}
