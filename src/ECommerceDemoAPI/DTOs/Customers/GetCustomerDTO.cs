namespace ECommerceDemoAPI.DTOs.Customers
{
    public class GetCustomerDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}