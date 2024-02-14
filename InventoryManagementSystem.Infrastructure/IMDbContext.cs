using InventoryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure;

public class IMDbContext:DbContext
{
    public IMDbContext(DbContextOptions<IMDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(p => p.ProductId);
        
        modelBuilder.Entity<Purchase>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(p => p.ProductId);
        
        modelBuilder.Entity<Stock>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(p => p.ProductId);
    }

    public DbSet<Product> Products {get; set;} 
    public DbSet<Purchase> Purchases {get; set;} 
    public DbSet<Sale> Sales {get; set;} 
    public DbSet<Stock> Stocks {get; set;} 


}