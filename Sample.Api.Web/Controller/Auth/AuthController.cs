
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.Application.Command;
using System.Threading.Tasks;

namespace Sample.Api.Web.Controller.Auth
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: APIController
    {
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(AddUserCommand command)
            => Ok(await Mediator.Send(command));
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
            => Ok(await Mediator.Send(command));
    }
}
