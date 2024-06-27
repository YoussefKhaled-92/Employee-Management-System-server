using Microsoft.EntityFrameworkCore;
using MyTask.DAL;

namespace MyTask.BAL
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public EmployeePaginated GetEmployeesPaginatedWithSearch(string? name, int? DepartmentId, int page, int pageSize)
        {
            var Employees = _unitOfWork.EmployeeRepository.GetAll()
                .Include(a => a.Department).AsQueryable();

            var count = _unitOfWork.EmployeeRepository.GetAll();

            if (name != null)
            {
                Employees = Employees.Where(a => a.Name.Contains(name));
                count = count.Where(a => a.Name.Contains(name));
            }

            if (DepartmentId != null)
            {
                Employees = Employees.Where(a => a.DepartmentId == DepartmentId);
                count = count.Where(a => a.DepartmentId == DepartmentId);
            }

            Employees = Employees.OrderBy(c => c.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsQueryable();

            var EmployeesPaginated = Employees.Select(c => new EmployeeReadDto
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                NationalId = c.NationalId,
                Phone = c.Phone,
                MobileNumber = c.MobileNumber,
                Position = c.Position,
                DepartmentId = c.Department.Id,
                DepartmentName = c.Department.Name,
                HiringDate = c.HiringDate,
                IsActive = c.IsActive,

            });

            return new EmployeePaginated
            {
                Employees = EmployeesPaginated,
                Count = count.Count()
            };
        }
        public void AddEmployee(EmployeeAddDto Employee)
        {
            Employee.HiringDate = Employee.HiringDate.AddDays(1);

            _unitOfWork.EmployeeRepository.Add(new Employee
            {
                Name = Employee.Name,
                Age = Employee.Age,
                NationalId = Employee.NationalId,
                Phone = Employee.Phone,
                MobileNumber = Employee.MobileNumber,
                Position = Employee.Position,
                DepartmentId = Employee.DepartmentId,
                IsActive = Employee.IsActive,
                HiringDate = Employee.HiringDate

            });
            _unitOfWork.Commit();
        }
        public Employee? UpdateEmployee(EmployeeUpdateDto Employee)
        {
            var EmployeeDb = _unitOfWork.EmployeeRepository.GetById(Employee.Id);
            if (EmployeeDb == null)
                return null;

            Employee.HiringDate = Employee.HiringDate.AddDays(1);
            
            EmployeeDb.Name = Employee.Name;
            EmployeeDb.Age = Employee.Age;
            EmployeeDb.NationalId = Employee.NationalId;
            EmployeeDb.Phone = Employee.Phone;
            EmployeeDb.MobileNumber = Employee.MobileNumber;
            EmployeeDb.Position = Employee.Position;
            EmployeeDb.DepartmentId = Employee.DepartmentId;
            EmployeeDb.IsActive = Employee.IsActive;
            EmployeeDb.HiringDate = Employee.HiringDate;
            _unitOfWork.Commit();

            return new Employee
            {
                Id = Employee.Id,
                Name = Employee.Name,
                Age = Employee.Age,
                NationalId = Employee.NationalId,
                DepartmentId = Employee.DepartmentId,
            };
        }
        public Employee? DeleteEmployee(int id) 
        {
            var EmployeeDb = _unitOfWork.EmployeeRepository.GetById(id);
            if (EmployeeDb == null)
                return null;
            else 
            {
                _unitOfWork.EmployeeRepository.Delete(EmployeeDb);
                _unitOfWork.Commit();

                return EmployeeDb;
            }
        }
    }
}
