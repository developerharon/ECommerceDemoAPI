namespace ECommerceDemoAPI.DTOs.OrderItems
{
    public class UpdateOrderItemDTO
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}