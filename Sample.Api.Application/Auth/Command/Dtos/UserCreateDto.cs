using Sample.Api.Domain.Common;
using Sample.Api.Domain.Enum;

namespace Sample.Api.Application.Command
{
   public class UserCreateDto: IMapFrom<AddUserCommand>
    {
        public string Name { get; set; }
        public RoleType Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
