using ECommerceDemoAPI.DTOs.Products;

namespace ECommerceDemoAPI.DTOs.OrderItems
{
    public class GetOrderItemDTO
    {
        public int Quantity { get; set; }
        public GetProductDTO Product { get; set; }
    }
}