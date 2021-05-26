using AutoMapper;
using MediatR;
using Sample.Api.Application.Common;
using Sample.Api.Application.Helper;
using Sample.Api.Domain.Enum;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Api.Application.Command
{
    public class AddUserCommand:IRequest<string>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }
    }
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IUserservice _userservice;
        public AddUserCommandHandler(IMapper mapper, IUserservice userservice) => (_mapper,_userservice) = (mapper,userservice);
        public async Task<string> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var (PasswordSalt, PasswordHash) = AuthHelper.GeneratePassword(request.Password);
            var userDto = _mapper.Map<UserCreateDto>(request);
            userDto.PasswordHash = PasswordHash;
            userDto.PasswordSalt = PasswordSalt;
            var result = await _userservice.RegisterUser(userDto);
            return result ? $"{userDto.Name} Registered Successfully" : $"{userDto.Name} falied to register";
        }
    }
}
