using Entities.Dto.Service;
using Entities.Dto.User;

namespace Entities.Dto.Employee
{
    public class EmployeeViewDto
    {
        public string Id { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public IEnumerable<ServiceViewDto> Services { get; set; }
        public UserViewDto User { get; set; }
    }
}
