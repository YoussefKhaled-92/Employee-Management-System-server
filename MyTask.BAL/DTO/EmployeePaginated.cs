namespace MyTask.BAL
{
    public class EmployeePaginated
    {
        public IEnumerable<EmployeeReadDto> Employees { get; set; } = new List<EmployeeReadDto>();
        public int Count { get; set; }
    }
}
