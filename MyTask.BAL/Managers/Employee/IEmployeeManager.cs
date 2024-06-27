using MyTask.DAL;

namespace MyTask.BAL
{
    public interface IEmployeeManager
    {        
        public EmployeePaginated GetEmployeesPaginatedWithSearch(string? name, int? DepartmentId,int page,int pageSize);
        public void AddEmployee(EmployeeAddDto Employee);
        public Employee? UpdateEmployee(EmployeeUpdateDto Employee);
        public Employee? DeleteEmployee(int id);

    }
}
