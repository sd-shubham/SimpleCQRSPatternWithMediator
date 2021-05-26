using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sample.Api.Application.Command;
using Sample.Api.Application.Common;
using Sample.Api.Application.Query;
using Sample.Api.Domain.Entity;

namespace Sample.Api.Infrastructure.Persistence
{
    [Injectable]
   public class EmployeeService: IEmployeeService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public EmployeeService(IApplicationDbContext dbContext, IMapper mapper) => (_dbContext,_mapper) =( dbContext,mapper);

        public async Task<EmployeeGetDto> Create(EmployeeCreateDto createDto)
        {
            var employee = _mapper.Map<Employee>(createDto);
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<EmployeeGetDto>(employee);
        }
        public async Task<IEnumerable<EmployeeGetDto>> GetAllEmployee()
        {
            return await _dbContext.Employees.ProjectTo<EmployeeGetDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
