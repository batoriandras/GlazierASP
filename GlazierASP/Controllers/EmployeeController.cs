using Database;
using Entities.Dto.Employee;
using Logic.Logic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController
    {
        EmployeeLogic employeeLogic;
        UserManager<AppUser> userManager;

        public EmployeeController(EmployeeLogic employeeLogic, UserManager<AppUser> userManager)
        {
            this.employeeLogic = employeeLogic;
            this.userManager = userManager;
        }

        [HttpPost]
        public void CreateEmployee(EmployeeCreateDto dto)
        {
            employeeLogic.CreateEmployee(dto);
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeViewDto>> GetAllEmployees()
        {
            return await employeeLogic.GetAllEmployees();
        }

        [HttpDelete("{id}")]
        public void DeleteEmployee(string id)
        {
            employeeLogic.DeleteEmployee(id);
        }
    }
}
