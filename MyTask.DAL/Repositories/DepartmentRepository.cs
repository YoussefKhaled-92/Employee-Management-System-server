



namespace MyTask.DAL
{
            
public interface IDepartmentRepository : IRepository<Department>
{
    //Add any additional repository methods other than the generic ones (GetAll, GetById, Delete, Add)
}

public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
{
    private ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IDepartmentRepository.cs file
}
}
