using Entities.Dto.Service;
using Logic.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ServicesController : ControllerBase
    {
        ServiceLogic serviceLogic;

        public ServicesController(ServiceLogic serviceLogic)
        {
            this.serviceLogic = serviceLogic;
        }

        [HttpGet]
        public IEnumerable<ServiceViewDto> GetAllServices()
        {
            return serviceLogic.GetAllServices();
        }

        [HttpPost]
        public void CreateService(ServiceCreateUpdateDto dto)
        {
            serviceLogic.CreateService(dto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void UpdateService(string id, [FromBody] ServiceCreateUpdateDto dto)
        {
            serviceLogic.UpdateService(id, dto);
        }

        [HttpGet("{id}")]
        public void GetService(string id)
        {
            serviceLogic.GetServiceById(id);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteService(string id)
        {
            serviceLogic.deleteService(id);
        }


    }
}
