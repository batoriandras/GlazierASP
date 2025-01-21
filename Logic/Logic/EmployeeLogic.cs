using Database;
using Entities.Dto.Employee;
using Entities.Dto.User;
using Entities.Models;
using Logic.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Logic.Logic
{
    public interface IEmployeeLogic
    {
        void CreateEmployee(EmployeeCreateDto dto);
        Task<IEnumerable<EmployeeViewDto>> GetAllEmployees();
        void DeleteEmployee(string employeeId);
    }

    public class EmployeeLogic : IEmployeeLogic
    {
        Repository<Employee> _employeeRepo;
        Repository<Service> _serviceRepo;
        DtoProvider _dtoProvider;
        UserManager<AppUser> userManager;

        public EmployeeLogic(Repository<Employee> Repository, DtoProvider dtoProvider, Repository<Service> serviceRepo, UserManager<AppUser> userManager)
        {
            _employeeRepo = Repository;
            _dtoProvider = dtoProvider;
            _serviceRepo = serviceRepo;
            this.userManager = userManager;
        }

        public void CreateEmployee(EmployeeCreateDto dto)
        {
            var employee = _dtoProvider.Mapper.Map<Employee>(dto);
            employee.DateOfEmployment = DateTime.Now;

            employee.Services = new List<Service>();
            foreach (var item in dto.ServiceIds)
            {
                employee.Services.Add(_serviceRepo.FindById(item));
            }
            _employeeRepo.Create(employee);
        }

        public async Task<IEnumerable<EmployeeViewDto>> GetAllEmployees()
        {
            var employees = await _employeeRepo.GetAll().Include(e => e.Services).ToListAsync();

            var employeeDtos = new List<EmployeeViewDto>();

            foreach (var employee in employees)
            {
                var employeeDto = _dtoProvider.Mapper.Map<EmployeeViewDto>(employee);
                var user = await userManager.FindByIdAsync(employee.UserId);
                employeeDto.User = _dtoProvider.Mapper.Map<UserViewDto>(user);

                employeeDtos.Add(employeeDto);
            }

            return employeeDtos;
        }

        public void DeleteEmployee(string employeeId)
        {
            var employee = _employeeRepo.FindById(employeeId);

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            else
            {
                _employeeRepo.Delete(employee);
            }
        }
    }
}
