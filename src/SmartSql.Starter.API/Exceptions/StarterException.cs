using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SmartSql.Starter.API.Exceptions
{
    public class StarterException : Exception
    {
        public StarterException()
        {
            ErrorCode = "0001";
        }
        /// <summary>
        /// 异常代码
        /// </summary>
        public String ErrorCode { get; set; }

        public StarterException(string errorCode) : base() { ErrorCode = errorCode; }

        public StarterException(string errorCode, string message) : base(message) { ErrorCode = errorCode; }

        public StarterException(string errorCode, SerializationInfo info, StreamingContext context) : base(info, context) { ErrorCode = errorCode; }

        public StarterException(string errorCode, string message, System.Exception innerException) : base(message, innerException) { ErrorCode = errorCode; }

    }
}
