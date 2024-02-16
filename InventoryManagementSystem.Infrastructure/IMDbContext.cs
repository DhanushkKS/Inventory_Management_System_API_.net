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
        modelBuilder.Entity<Product>()
            .Property(p => p.CreatedAt)
            .HasColumnType("timestamp without time zone");
        
        modelBuilder.Entity<Purchase>()
            .Property(p => p.CreatedAt)
            .HasColumnType("timestamp without time zone");
        
        modelBuilder.Entity<Stock>()
            .Property(p => p.CreatedAt)
            .HasColumnType("timestamp without time zone");
        modelBuilder.Entity<Stock>()
            .Property(p => p.ModifiedDate)
            .HasColumnType("timestamp without time zone");
        modelBuilder.Entity<Sale>()
            .Property(p => p.CreatedAt)
            .HasColumnType("timestamp without time zone");
        
        
        modelBuilder.Entity<Sale>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(p => p.ProductId)
            
            ;
            
        modelBuilder.Entity<Purchase>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(p => p.ProductId);
        
        modelBuilder.Entity<Stock>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(p => p.ProductId);
        //Data seed
        modelBuilder.Entity<Product>()
            .HasData(new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Category = "Electronic",
                    CreatedAt = DateTime.Now,
                    Name = "Apple Iphone 15",
                    Price = 34.55f,
                    ProductDetails = "Apple smart phone"
                },
                new Product()
                {
                    Id = 2,
                    Category = "Electronic",
                    CreatedAt = DateTime.Now,
                    Name = "Apple Iphone 15",
                    Price = 34.55f,
                    ProductDetails = "Apple smart phone"
                }
            }  );
    }

    public DbSet<Product> Products {get; set;} 
    public DbSet<Purchase> Purchases {get; set;} 
    public DbSet<Sale> Sales {get; set;} 
    public DbSet<Stock> Stocks {get; set;} 


}