using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.Api.Web.Controller
{
    public class APIController : ControllerBase {
        private readonly ISender _mediator;
        public ISender Mediator => _mediator ?? HttpContext.RequestServices.GetService<ISender>();
    }
}
