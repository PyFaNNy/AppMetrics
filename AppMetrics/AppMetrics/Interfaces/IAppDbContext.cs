using AppMetrics.Domain;
using Microsoft.EntityFrameworkCore;

namespace AppMetrics.Interfaces;

public interface IAppDbContext
{
    public DbSet<Customer> Customers { get; set; }
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    public int SaveChanges();
}