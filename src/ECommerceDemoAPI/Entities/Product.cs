using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ECommerceDemoAPI.Entities
{
    public class Product : BaseEntity
    {
        [Required, StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        
        [Required, Precision(14, 2)]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        // Navigation properties
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}