using SmartSql.Starter.Entitiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSql.Starter.API.Message.Response.User
{
    public class GetUserInfoResponse
    {
        public Item User { get; set; }
        public UserExtendData ExtendData { get; set; }
    }
}
