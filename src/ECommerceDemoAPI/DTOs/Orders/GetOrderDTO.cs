using ECommerceDemoAPI.DTOs.Customers;
using ECommerceDemoAPI.DTOs.OrderItems;
using ECommerceDemoAPI.Entities;

namespace ECommerceDemoAPI.DTOs.Orders
{
    public class GetOrderDTO
    {
        public Guid Id { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset? ShippingDate { get; set; }
        public DateTimeOffset? DeliveryDate { get; set; }
        public string? Notes { get; set; }
        public decimal OrderTotal { get; set; }
        public List<GetOrderItemDTO> OrderItems { get; set; } = new List<GetOrderItemDTO>();
        public GetCustomerDTO? Customer { get; set; }
    }
}