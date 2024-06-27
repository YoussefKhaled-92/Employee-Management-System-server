using System.ComponentModel.DataAnnotations;

namespace MyTask.BAL
{
    public class EmployeeUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    
        [Range(10, 100, ErrorMessage = "Age Must be 10~100")]
        public int Age { get; set; }
        [StringLength(14, MinimumLength = 14, ErrorMessage = "NationalId length must be 14")]
        public string NationalId { get; set; } = string.Empty;
        public string Phone { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime HiringDate { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
    }
}