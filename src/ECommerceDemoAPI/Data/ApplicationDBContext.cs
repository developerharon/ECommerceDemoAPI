using ECommerceDemoAPI.Entities;
using ECommerceDemoAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.Data
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var tracker = ChangeTracker;

            foreach (var entry in tracker.Entries())
            {
                if (entry.Entity is BaseEntity)
                {
                    var referenceEntity = entry.Entity as BaseEntity;

                    if (referenceEntity is null)
                        continue;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            referenceEntity.CreatedAt = DateTimeOffset.UtcNow;
                            break;
                        case EntityState.Deleted:
                        case EntityState.Modified:
                            referenceEntity.UpdatedAt = DateTimeOffset.UtcNow;
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}