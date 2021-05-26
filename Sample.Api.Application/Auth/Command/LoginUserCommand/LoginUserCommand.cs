using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Sample.Api.Application.Common;
using Sample.Api.Application.Helper;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Api.Application.Command
{
   public class LoginUserCommand: IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserservice _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginUserCommandHandler(IUserservice userservice, IMapper mapper, IConfiguration configuration) 
            => (_userService,_mapper,_configuration) = (userservice,mapper,configuration);
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.Login(_mapper.Map<LoginRequsetDto>(request));
            var isUserPasswordValid = AuthHelper.IsUserPasswordvalid(request.Password, user.PasswordHash, user.PasswordSalt);
            if (!isUserPasswordValid) throw new System.Exception("invalid username or password");
            return AuthHelper.GenerateToken(user, _configuration);
        }
    }
}
