using BGTest.Core.Entities;
using BGTest.Core.Views;
using Microsoft.EntityFrameworkCore;

namespace BGTest.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public DbSet<ProductBatches> ProductBatches { get; set; }
    
    public DbSet<ProductBatchView> ProductBatchesView { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ProductBatchView>()
            .ToView("vw_productbatches") // Map the entity to the SQL view vw_ProductBatches
            .HasNoKey(); // Since views don’t have primary keys
    }
}