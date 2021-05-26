

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Sample.Api.Web.Controller.Error
{
    [ApiController]
    public class ErrorController: ControllerBase
    {
        [Route("/development-error")]
        public IActionResult HandleError([FromServices]IWebHostEnvironment environment)
        {
            if(environment.EnvironmentName != "Development")
                throw new InvalidOperationException($"invalid {environment} environment");
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error?.InnerException?.Message ?? context.Error.Message
            );
        }
    }
}
