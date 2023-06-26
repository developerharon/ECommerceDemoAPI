using ECommerceDemoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.Interfaces
{
    public interface IApplicationDBContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}