using AppMetrics.Domain;
using AppMetrics.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppMetrics.AppContext;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; }
    
    public override int SaveChanges()
    {
        var result = base.SaveChanges();

        return result;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}