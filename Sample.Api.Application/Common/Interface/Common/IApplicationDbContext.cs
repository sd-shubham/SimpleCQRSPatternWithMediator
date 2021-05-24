using Microsoft.EntityFrameworkCore;
using Sample.Api.Domain.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Api.Application.Common
{
   public interface IApplicationDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
