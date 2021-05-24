using AutoMapper;
using MediatR;
using Sample.Api.Application.Common;
using Sample.Api.Application.Query;
using Sample.Api.Domain.Common;
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
        private readonly IApplicationDbContext _dbContext;
        public AddEmployeeCommandhandler(IMapper mapper,IApplicationDbContext dbContext) =>( _mapper,_dbContext) = (mapper,dbContext);
        public async Task<EmployeeGetDto> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            // we can craete a seprate service and pass the create dto 
            var employee = _mapper.Map<Employee>(_mapper.Map<EmployeeCreateDto>(request));
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<EmployeeGetDto>(employee);
        }
    }
}