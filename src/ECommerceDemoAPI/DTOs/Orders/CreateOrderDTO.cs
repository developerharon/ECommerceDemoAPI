using ECommerceDemoAPI.DTOs.OrderItems;
using System.ComponentModel.DataAnnotations;

namespace ECommerceDemoAPI.DTOs.Orders
{
    public class CreateOrderDTO
    {
        public DateTimeOffset? ShippingDate { get; set; }
        public DateTimeOffset? DeliveryDate { get; set; }
        [StringLength(300)]
        public string Notes { get; set; }
        public List<CreateOrderItemDTO> OrderItems { get; set; } = new List<CreateOrderItemDTO>();
    }
}