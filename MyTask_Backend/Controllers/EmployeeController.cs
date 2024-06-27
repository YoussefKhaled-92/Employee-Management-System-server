using Microsoft.AspNetCore.Mvc;
using MyTask.BAL;

namespace MyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _EmployeeManager;

        public EmployeeController(IEmployeeManager EmployeeManager)
        {
            _EmployeeManager = EmployeeManager;
        }


        [HttpGet("{page=1}/{pageSize=10}")]
        public ActionResult<EmployeePaginated> GetEmployeePaginated(
            [FromQuery] string? name,
            [FromQuery] int? Department,
            int page,
            int pageSize)
        {
            return _EmployeeManager.GetEmployeesPaginatedWithSearch(name, Department, page, pageSize);
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeAddDto Employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _EmployeeManager.AddEmployee(Employee);
            return NoContent();
        }
        [HttpPut]
        public ActionResult EditEmployee(EmployeeUpdateDto Employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var EmployeeChecked = _EmployeeManager.UpdateEmployee(Employee);
            if(EmployeeChecked != null)
            {
                return Ok(EmployeeChecked);
            }
            else
            { 
                return BadRequest("Employee doesn`t exists");
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var EmployeeChecked = _EmployeeManager.DeleteEmployee(id);

            if (EmployeeChecked != null)
                return Ok(EmployeeChecked);
            else
                return BadRequest("Employee doesn`t exists");
        }
    }
}
