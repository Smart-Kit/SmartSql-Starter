using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSql.Starter.API.Message
{
    public class ResponseMessageWraper<T>
    {
        const string SUCCESS_CODE = "0000";
        public ResponseMessageWraper()
        {
            IsSuccess = true;
            ErrorCode = SUCCESS_CODE;
        }
        public bool IsSuccess { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public T Body { get; set; }
    }
}
