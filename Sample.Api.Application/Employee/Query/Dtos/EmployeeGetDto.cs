using Sample.Api.Domain.Common;
using Sample.Api.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Api.Application.Query
{
   public class EmployeeGetDto: IMapFrom<Employee>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<EmployeeAddressGetDto> Addresses { get; set; }
    }
}
