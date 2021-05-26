using Sample.Api.Domain.Common;
using Sample.Api.Domain.Entity;
using Sample.Api.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Api.Application.Query
{
   public class UserGetDto: IMapFrom<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoleType Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
