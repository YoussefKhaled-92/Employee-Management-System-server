using Microsoft.EntityFrameworkCore;
using System;

namespace MyTask.DAL
{
public class UnitOfWork : IUnitOfWork
{

	#region Constructors

	public UnitOfWork(ApplicationDbContext context)
    {
        Context = context;

    }

	//Delete this default constructor if using an IoC container
	//public UnitOfWork()
	//{
	//	Context = new ApplicationDbContext();
	//}
	
	#endregion

	#region Properties

	 #region Private

	 private ApplicationDbContext _context;

	 private ApplicationDbContext Context
        {
            get { return _context; }
            set
            {
                _context = value;
				if (_context != null)
                {
					_context.Database.SetCommandTimeout(180);
				}
            }
        }

	 

    
	private IDepartmentRepository _Department;

    
	private IEmployeeRepository _Employee;

    

    
	 #endregion

	 #region Public

    
	public IDepartmentRepository DepartmentRepository
    {
        get { return _Department ?? (_Department = new DepartmentRepository(Context)); }
    }

    
	public IEmployeeRepository EmployeeRepository
    {
        get { return _Employee ?? (_Employee = new EmployeeRepository(Context)); }
    }

    
	 #endregion

	#endregion

	#region Methods

	public void Commit()
    {
        Context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }
    }

	#endregion

}
}
