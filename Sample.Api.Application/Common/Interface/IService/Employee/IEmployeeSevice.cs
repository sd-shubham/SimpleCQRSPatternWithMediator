using Sample.Api.Application.Command;
using Sample.Api.Application.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Api.Application.Common
{
   public interface IEmployeeService
    {
        Task<EmployeeGetDto> Create(EmployeeCreateDto createDto);
        Task<IEnumerable<EmployeeGetDto>> GetAllEmployee();
    }
}
