using AutoMapper;
using Database;
using Entities.Dto.Order;
using Entities.Dto.Service;
using Entities.Dto.User;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Logic.Helpers
{
    public class DtoProvider
    {
        UserManager<AppUser> userManager;

        public Mapper Mapper { get; }

        public DtoProvider(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderShortViewDto>();

                cfg.CreateMap<AppUser, UserViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.Role = userManager.IsInRoleAsync(src, "Admin").Result;
                });


                cfg.CreateMap<Order, OrderViewDto>()
                .AfterMap((src, dest) =>
                {
                    var user = userManager.Users.First(u => u.Id == src.UserId);
                    dest.UserFullName = user.LastName! + " " + user.FirstName;
                });
                cfg.CreateMap<OrderCreateDto, Order>();
                cfg.CreateMap<OrderUpdateDto, Service>();
                cfg.CreateMap<ServiceCreateUpdateDto, Service>();
                cfg.CreateMap<Service, ServiceViewDto>();
            });

            Mapper = new Mapper(config);
        }
    }
}
