using MyTask.DAL;

namespace MyTask.BAL.Managers.Department
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DepartmentReadDto> GetAll()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();

            return departments.Select(g => new DepartmentReadDto
            {
                DepartmentId = g.Id,
                DepartmentName = g.Name,
                DepartmentDetails = g.Details,
                DepartmentOrder = g.Order

            }).ToList();

        }
    }
}
