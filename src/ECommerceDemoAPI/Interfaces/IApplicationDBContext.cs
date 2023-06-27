using ECommerceDemoAPI.Entities;
using ECommerceDemoAPI.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.Interfaces
{
    public interface IApplicationDBContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}