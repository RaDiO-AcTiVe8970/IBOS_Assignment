using System.ComponentModel.DataAnnotations;

namespace Assignment.DTO
{
    public class EmployeeDTO

    {
        public int EmployeeId { get; set; }
        [Required]
        public required string EmployeeName { get; set; }
        [Required]
        public required string EmployeeCode { get; set; }
        [Required]
        public decimal EmployeeSalary { get; set; }
        [Required]
        public int? SupervisorId { get; set; }
    }
}
