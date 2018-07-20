using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSql.Starter.API.Message.Request.User
{
    public class GetExtendDataRequest : RequestMessage
    {
        public long UserId { get; set; }
    }
}
