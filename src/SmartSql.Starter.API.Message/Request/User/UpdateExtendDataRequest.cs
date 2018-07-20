using SmartSql.Starter.Entitiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSql.Starter.API.Message.Request.User
{
    public class UpdateExtendDataRequest : RequestMessage
    {
        public long UserId { get; set; }
        public UserInfo Info { get; set; }
    }
}
