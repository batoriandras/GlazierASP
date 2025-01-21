﻿using Database;
using Entities.Dto.Order;
using Entities.Models;
using Logic.Helpers;

namespace Logic.Logic
{
    public interface IOrderLogic
    {
        void CreateOrder(OrderCreateDto dto, string userId);
        IEnumerable<OrderViewDto> GetAllOrders();
        void DeleteOrder(string id);
        IEnumerable<OrderShortViewDto> GetOrdersByUserId(string userId);
        OrderViewDto GetOrderById(string id);
        OrderShortViewDto GetShortOrderById(string id);
        void UpdateOrderStatus(string id, OrderStatus status);
    }

    public class OrderLogic : IOrderLogic
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
            if (status == OrderStatus.Completed)
            {
                order.CompletionDate = DateTime.Now;
            }
            _orderRepository.Update(order);
        }
    }
}
