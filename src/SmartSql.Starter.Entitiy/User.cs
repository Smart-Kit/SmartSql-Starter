using System;

namespace SmartSql.Starter.Entitiy
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime CreationTime { get; set; }
    }

    public enum UserStatus
    {
        Ok = 1
    }
}
