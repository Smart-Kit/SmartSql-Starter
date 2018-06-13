using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartSql.Starter.API.Message.Request.User
{
    public class GetByIdRequest : RequestMessage
    {
        [Required]
        public long Id { get; set; }
    }
}
