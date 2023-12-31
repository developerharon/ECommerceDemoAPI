﻿using System.ComponentModel.DataAnnotations;

namespace ECommerceDemoAPI.Entities
{
    public class Order : BaseEntity
    {
        public DateTimeOffset? ShippingDate { get; set; }
        public DateTimeOffset? DeliveryDate { get; set; }
        [StringLength(300)]
        public string Notes { get; set; }

        // Foreign keys
        public Guid? CustomerId { get; set; }

        // Navigation properties
        public virtual List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual Customer Customer { get; set; }

        // Not saved to the database, helps with normalization
        public decimal OrderTotal => OrderItems.Sum(x => x.Quantity * x.Product.Price);
    }
}
