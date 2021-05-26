using AutoMapper;
using MediatR;
using Sample.Api.Application.Common;
using Sample.Api.Application.Query;
using Sample.Api.Domain.Entity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Api.Application.Command
{
    public class AddEmployeeCommand:IRequest<EmployeeGetDto>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<EmployeeAddressCreateDto> Addresses { get; set; }
    }
    public class AddEmployeeCommandhandler : IRequestHandler<AddEmployeeCommand, EmployeeGetDto>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeSevice;
        public AddEmployeeCommandhandler(IMapper mapper,IEmployeeService employeeSevice) 
            =>( _mapper,_employeeSevice) = (mapper,employeeSevice);
        public async Task<EmployeeGetDto> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            // we can craete a seprate service and pass the create dto 
            return await _employeeSevice.Create(_mapper.Map<EmployeeCreateDto>(request));
        }
    }
}