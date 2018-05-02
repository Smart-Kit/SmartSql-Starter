using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSql.Starter.API.Message
{
    public class QueryByPageRequest : RequestMessage
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int Offset { get { return (PageIndex - 1) * PageSize; } }
    }
}
