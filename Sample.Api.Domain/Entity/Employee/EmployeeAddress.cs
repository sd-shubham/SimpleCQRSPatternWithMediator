
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Api.Domain.Entity
{
    public class EmployeeAddress
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string State { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
    }
}
