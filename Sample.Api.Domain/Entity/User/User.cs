using Sample.Api.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sample.Api.Domain.Entity
{
   public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public RoleType Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
