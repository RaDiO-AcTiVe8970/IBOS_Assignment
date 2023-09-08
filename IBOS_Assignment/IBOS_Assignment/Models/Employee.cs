using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public required string EmployeeName { get; set; }
        [Required]
        public required string EmployeeCode { get; set; }
        [Required]
        public decimal EmployeeSalary { get; set; }
        [Required]
        public int? SupervisorId { get; set; }
       
        public ICollection<EmployeeAttendance>? EmployeeAttendances { get; set; }
    }
}
