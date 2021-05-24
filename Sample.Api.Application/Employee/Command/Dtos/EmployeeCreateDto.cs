using System.Collections.Generic;
using AutoMapper;
using Sample.Api.Domain.Common;
using Sample.Api.Domain.Entity;

namespace Sample.Api.Application.Command
{
   public class EmployeeCreateDto: IMapFrom<AddEmployeeCommand>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<EmployeeAddressCreateDto> Addresses { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmployeeCreateDto, Employee>();
            profile.CreateMap<EmployeeAddressCreateDto, EmployeeAddress>();
            profile.CreateMap<AddEmployeeCommand, EmployeeCreateDto>();
        }
    }
}
