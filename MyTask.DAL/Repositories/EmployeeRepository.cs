
                
			

namespace MyTask.DAL
{
            
public interface IEmployeeRepository : IRepository<Employee>
{
    //Add any additional repository methods other than the generic ones (GetAll, GetById, Delete, Add)
    public int GetCount();
}
  
public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    private ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

        public int GetCount()
        {
            return _context.Employees.Count();
        }

        //Override any generic method for your own custom implemention, add new repository methods to the IEmployeeRepository.cs file
    }
}
