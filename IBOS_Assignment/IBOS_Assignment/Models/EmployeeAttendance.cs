using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Assignment.Models
{
    public class EmployeeAttendance
    {
        [Key]
        public int EmployeeAttendanceId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime AttendanceDate { get; set; }
        [Required]
        public bool IsPresent { get; set; }
        [Required]
        public bool IsAbsent { get; set; }
        [Required]
        public bool IsOffday { get; set; }
        
        public virtual required Employee Employee { get; set; }
    }
}
