
using AutoMapper;
using Sample.Api.Domain.Common;
using Sample.Api.Domain.Entity;

namespace Sample.Api.Application.Command
{
    public class EmployeeAddressCreateDto: IMapFrom<EmployeeAddress>
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

    }
}
