using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSql.Starter.API.Message
{
    public class QueryByPageResponse<T> : QueryResponse<T>
    {
        public int Total { get; set; }
    }
}
