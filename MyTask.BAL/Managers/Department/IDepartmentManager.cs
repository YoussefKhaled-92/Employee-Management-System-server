using MyTask.DAL;

namespace MyTask.BAL
{
    public interface IDepartmentManager
    {
        public IEnumerable<DepartmentReadDto> GetAll();
    }
}
