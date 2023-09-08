using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment.DTO
{
    public class EmployeeAttendanceDTO
    {
        public int EmployeeAttendanceId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime AttendanceDate { get; set; }
        [Required]
        public bool IsPresent { get; set; }
        [Required]
        public bool IsAbsent { get; set; }
        [Required]
        public bool IsOffday { get; set; }
    }
}
