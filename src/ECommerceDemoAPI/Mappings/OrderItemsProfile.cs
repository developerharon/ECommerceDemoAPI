using AutoMapper;
using ECommerceDemoAPI.DTOs.OrderItems;
using ECommerceDemoAPI.Entities;

namespace ECommerceDemoAPI.Mappings
{
    public class OrderItemsProfile : Profile
    {
        public OrderItemsProfile()
        {
            CreateMap<OrderItem, GetOrderItemDTO>();
            CreateMap<CreateOrderItemDTO, OrderItem>();
        }
    }
}