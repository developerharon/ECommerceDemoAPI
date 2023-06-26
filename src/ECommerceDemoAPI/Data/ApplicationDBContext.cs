using ECommerceDemoAPI.Entities;
using ECommerceDemoAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.Data
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}