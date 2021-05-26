using Sample.Api.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Api.Application.Command
{
   public class LoginRequsetDto: IMapFrom<LoginUserCommand>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
