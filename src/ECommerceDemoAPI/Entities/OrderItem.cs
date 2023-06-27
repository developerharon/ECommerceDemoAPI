using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDemoAPI.Entities
{
    [Table("OrderItems")]
    public class OrderItem : BaseEntity
    {
        [Required, DefaultValue(1)]
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        
        // navigation properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}