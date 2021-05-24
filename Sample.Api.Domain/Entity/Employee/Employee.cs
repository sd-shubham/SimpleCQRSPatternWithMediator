
using Sample.Api.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Api.Domain.Entity
{
   public class Employee
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public IEnumerable<EmployeeAddress> Addresses { get; set; }
    }
}
