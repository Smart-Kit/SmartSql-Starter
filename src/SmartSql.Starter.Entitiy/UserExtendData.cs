using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSql.Starter.Entitiy
{
    public class UserExtendData
    {
        public long UserId { get; set; }
        public UserInfo Info { get; set; }
    }

    public class UserInfo
    {
        public string QQ { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
