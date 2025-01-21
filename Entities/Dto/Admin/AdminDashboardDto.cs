namespace Entities.Dto.Admin
{
    public class AdminDashboardDto
    {
        public int ActiveProjects { get; set; }
        public int CompletedOrders { get; set; }
        public int TotalUsers { get; set; }
        public int TotalOrders { get; set; }
        public int TotalServices { get; set; }
        public int TotalEmployees { get; set; }
    }
}
