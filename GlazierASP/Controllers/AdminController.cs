using Entities.Dto.Admin;
using Logic.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        AdminDashboardLogic adminDashboardLogic;

        public AdminController(AdminDashboardLogic adminDashboardLogic)
        {
            this.adminDashboardLogic = adminDashboardLogic;
        }

        [HttpGet]
        public AdminDashboardDto GetAdminDashboard()
        {
            return adminDashboardLogic.GetDashboardData();
        }

    }
}
