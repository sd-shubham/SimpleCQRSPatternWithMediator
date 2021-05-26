using MediatR;
using Sample.Api.Application.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Api.Application.Query
{
    public class GetAllEmployee : IRequest<IEnumerable<EmployeeGetDto>>
    {

    }
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployee, IEnumerable<EmployeeGetDto>>
    {
        private readonly IEmployeeService _employeeSevice;
        public GetAllEmployeeHandler(IEmployeeService employeeSevice)
            => _employeeSevice = employeeSevice;
        public async Task<IEnumerable<EmployeeGetDto>> Handle(GetAllEmployee request, CancellationToken cancellationToken)
                    => await _employeeSevice.GetAllEmployee();

    }
}
