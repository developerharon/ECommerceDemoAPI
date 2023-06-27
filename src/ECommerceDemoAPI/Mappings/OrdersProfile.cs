using AutoMapper;
using ECommerceDemoAPI.DTOs.Orders;
using ECommerceDemoAPI.Entities;

namespace ECommerceDemoAPI.Mappings
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, GetOrderDTO>();
        }
    }
}