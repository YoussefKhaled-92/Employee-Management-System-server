namespace MyTask.BAL
{
    public class DepartmentReadDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string DepartmentDetails { get; set; } = string.Empty;
        public int DepartmentOrder { get; set; }
    }
}