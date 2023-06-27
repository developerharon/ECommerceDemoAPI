using System.ComponentModel.DataAnnotations;

namespace ECommerceDemoAPI.DTOs.Customers
{
    public class UpdateCustomerDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required, StringLength(15, MinimumLength = 10)]
        public string Phone { get; set; }
        [Required, EmailAddress, StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }
    }
}