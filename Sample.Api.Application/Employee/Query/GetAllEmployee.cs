using AutoMapper;
using MediatR;
using Sample.Api.Domain.Entity;
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
        private readonly IMapper _mapper;
        public GetAllEmployeeHandler(IMapper mapper) => _mapper = mapper;
        public async Task<IEnumerable<EmployeeGetDto>> Handle(GetAllEmployee request, CancellationToken cancellationToken)
        {
            return  await Task.FromResult(_mapper.Map<IEnumerable<EmployeeGetDto>>(new List<Employee> { new Employee { FirstName = "shubham" } }));
        }
    }
}
