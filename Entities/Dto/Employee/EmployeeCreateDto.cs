namespace Entities.Dto.Employee
{
    public class EmployeeCreateDto
    {
        public required string UserId { get; set; } = "";
        public required DateTime DateOfEmployment { get; set; } = DateTime.Now;
        public required string[] ServiceIds { get; set; } = new string[0];
    }
}
