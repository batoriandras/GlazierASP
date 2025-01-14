using Database;
using Entities.Dto.Service;
using Entities.Models;
using Logic.Helpers;

namespace Logic.Logic
{
    public class ServiceLogic
    {
        Repository<Service> _serviceRepository;
        DtoProvider _dtoProvider;

        public ServiceLogic(Repository<Service> serviceRepository, DtoProvider dtoProvider)
        {
            _serviceRepository = serviceRepository;
            _dtoProvider = dtoProvider;
        }

        public void CreateService(ServiceCreateUpdateDto dto)
        {
            Service service = _dtoProvider.Mapper.Map<Service>(dto);
            _serviceRepository.Create(service);
        }

        public void UpdateService(string id, ServiceCreateUpdateDto dto)
        {
            var old = _serviceRepository.FindById(id);
            _dtoProvider.Mapper.Map(dto, old);
            _serviceRepository.Update(old);
        }

        public IEnumerable<ServiceViewDto> GetAllServices()
        {
            return _serviceRepository.GetAll().Select(x => _dtoProvider.Mapper.Map<ServiceViewDto>(x));
        }

        public void deleteService(string id)
        {
            _serviceRepository.DeleteById(id);
        }
    }
}
