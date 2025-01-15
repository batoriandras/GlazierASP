using Database;
using Entities.Dto.Admin;
using Entities.Models;

namespace Logic.Logic
{
    public class AdminDashboardLogic
    {
        AppDbContext _context;

        public AdminDashboardLogic(AppDbContext context)
        {
            _context = context;
        }

        public AdminDashboardDto GetDashboardData()
        {
            var activeProjects = _context.Orders.Count(x => x.Status == OrderStatus.InProgress);
            var completedOrders = _context.Orders.Count(x => x.Status == OrderStatus.Completed);
            var totalUsers = _context.Users.Count();
            var totalOrders = _context.Orders.Count();
            var totalServices = _context.Services.Count();

            return new AdminDashboardDto
            {
                ActiveProjects = activeProjects,
                CompletedOrders = completedOrders,
                TotalUsers = totalUsers,
                TotalOrders = totalOrders,
                TotalServices = totalServices
            };
        }
    }
}
