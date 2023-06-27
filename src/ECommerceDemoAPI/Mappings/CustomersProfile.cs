using AutoMapper;
using ECommerceDemoAPI.DTOs.Customers;
using ECommerceDemoAPI.Entities;

namespace ECommerceDemoAPI.Mappings
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Customer, GetCustomerDTO>();
        }
    }
}