namespace MyTask.BAL
{
    public class EmployeeReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public int Age { get; set; }
        public string NationalId { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime HiringDate { get; set; }

    }
}