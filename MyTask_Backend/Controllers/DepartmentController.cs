using Microsoft.AspNetCore.Mvc;
using MyTask.BAL;

namespace MyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentManager _DepartmentManager;

        public DepartmentController(IDepartmentManager DepartmentManager)
        {
            _DepartmentManager = DepartmentManager;
        }
        [HttpGet]
        public ActionResult<List<DepartmentReadDto>> Get()
        {
            return _DepartmentManager.GetAll().ToList();
        }

    }
}
