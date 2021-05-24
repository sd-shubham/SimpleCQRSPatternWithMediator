

using Sample.Api.Domain.Common;
using Sample.Api.Domain.Entity;

namespace Sample.Api.Application.Query
{
   public class EmployeeAddressGetDto: IMapFrom<EmployeeAddress>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
