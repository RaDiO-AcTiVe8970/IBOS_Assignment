using System.ComponentModel.DataAnnotations;

namespace Assignment.DTO
{
    public class EmployeeHierarchyDTO
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public List<EmployeeHierarchyDTO> Subordinates { get; set; }
    }
}
