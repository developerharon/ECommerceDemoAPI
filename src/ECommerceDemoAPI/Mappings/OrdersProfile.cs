using AutoMapper;
using ECommerceDemoAPI.DTOs.Orders;
using ECommerceDemoAPI.Entities;

namespace ECommerceDemoAPI.Mappings
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, GetOrderDTO>()
                .ForMember(x => x.OrderDate, opts => opts.MapFrom(y => y.CreatedAt));
            CreateMap<CreateOrderDTO, Order>();
        }
    }
}