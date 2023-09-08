using System.ComponentModel.DataAnnotations;

namespace Assignment.DTO
{
    public class MonthlyAttendanceReportDTO
    {
        [Required]
        public required string EmployeeName { get; set; }
        [Required]
        public required string MonthName { get; set; }
        [Required]
        public decimal PayableSalary { get; set; }
        [Required]
        public int TotalPresent { get; set; }
        [Required]
        public int TotalAbsent { get; set; }
        [Required]
        public int TotalOffday { get; set; }
    }
}
