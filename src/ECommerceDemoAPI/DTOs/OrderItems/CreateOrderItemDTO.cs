namespace ECommerceDemoAPI.DTOs.OrderItems
{
    public class CreateOrderItemDTO
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}