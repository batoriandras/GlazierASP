﻿using Database;
using Entities.Dto.Order;
using Entities.Models;
using Logic.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderLogic orderLogic;
        UserManager<AppUser> userManager;

        public OrderController(OrderLogic orderLogic, UserManager<AppUser> userManager)
        {
            this.orderLogic = orderLogic;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task CreateOrder(OrderCreateDto dto)
        {
            var user = await userManager.GetUserAsync(User);
            orderLogic.CreateOrder(dto, user.Id);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<OrderViewDto> GetAllOrders()
        {
            return orderLogic.GetAllOrders();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void UpdateOrderStatus(string id, OrderStatus status)
        {
            orderLogic.UpdateOrderStatus(id, status);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteOrder(string id)
        {
            orderLogic.DeleteOrder(id);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public OrderViewDto GetOrder(string id)
        {
            return orderLogic.GetOrderById(id);
        }

        [HttpGet]
        public async OrderShortViewDto GetShortOrder()
        {
            var user = await userManager.GetUserAsync(User);
            return orderLogic.GetShortOrderById(user.Id);
        }
    }
}
