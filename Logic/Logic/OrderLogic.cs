using Database;
using Entities.Dto.Order;
using Entities.Models;
using Logic.Helpers;

namespace Logic.Logic
{
    public class OrderLogic
    {
        Repository<Order> _orderRepository;
        DtoProvider _dtoProvider;

        public OrderLogic(Repository<Order> orderRepository, DtoProvider dtoProvider)
        {
            _orderRepository = orderRepository;
            _dtoProvider = dtoProvider;
        }

        public void CreateOrder(OrderCreateDto dto, string userId)
        {
            var order = _dtoProvider.Mapper.Map<Order>(dto);
            order.UserId = userId;
            _orderRepository.Create(order);
        }

        public void UpdateOrder(string id, OrderUpdateDto dto)
        {
            var old = _orderRepository.FindById(id);
            _dtoProvider.Mapper.Map(dto, old);
            _orderRepository.Update(old);
        }

        public IEnumerable<OrderViewDto> GetAllOrders()
        {
            return _orderRepository.GetAll().Select(x => _dtoProvider.Mapper.Map<OrderViewDto>(x));
        }

        public void DeleteOrder(string id)
        {
            _orderRepository.DeleteById(id);
        }

        public IEnumerable<OrderShortViewDto> GetOrdersByUserId(string userId)
        {
            return _orderRepository.GetAll().Where(x => x.UserId == userId).Select(x => _dtoProvider.Mapper.Map<OrderShortViewDto>(x));
        }

        public OrderViewDto GetOrderById(string id)
        {
            return _dtoProvider.Mapper.Map<OrderViewDto>(_orderRepository.FindById(id));
        }

        public OrderShortViewDto GetShortOrderById(string id)
        {
            return _dtoProvider.Mapper.Map<OrderShortViewDto>(_orderRepository.FindById(id));
        }

        public void UpdateOrderStatus(string id, OrderStatus status)
        {
            var order = _orderRepository.FindById(id);
            order.Status = status;
            _orderRepository.Update(order);
        }
    }
}
