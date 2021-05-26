using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.Application.Command;
using Sample.Api.Application.Query;
using System.Threading.Tasks;

namespace Sample.Api.Web.Controller
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmployeeController: APIController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await Mediator.Send(new GetAllEmployee()));
        [HttpPost]
        public async Task<IActionResult> Create(AddEmployeeCommand command)
            => Ok(await Mediator.Send(command));

    }
}
