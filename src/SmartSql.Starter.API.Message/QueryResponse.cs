using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSql.Starter.API.Message
{
    public class QueryResponse<T>
    {
        public IEnumerable<T> List { get; set; }
    }
}
