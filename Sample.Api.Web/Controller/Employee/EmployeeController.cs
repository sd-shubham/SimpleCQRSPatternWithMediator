using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.Application.Command;
using Sample.Api.Application.Query;
using System.Threading.Tasks;

namespace Sample.Api.Web.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController: ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator) => _mediator = mediator;
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _mediator.Send(new GetAllEmployee()));
        [HttpPost]
        public async Task<IActionResult> Create(AddEmployeeCommand command)
            => Ok(await _mediator.Send(command));

    }
}
