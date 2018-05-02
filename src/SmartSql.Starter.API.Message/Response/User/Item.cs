using SmartSql.Starter.Entitiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSql.Starter.API.Message.Response.User
{
    public class Item
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public UserStatus Status { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
