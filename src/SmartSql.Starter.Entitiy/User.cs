using System;

namespace SmartSql.Starter.Entitiy
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public UserStatus Status { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime CreationTime { get; set; }
        public bool Deleted { get; set; }
    }

    public enum UserStatus
    {
        Ok = 1
    }
}
