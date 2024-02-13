using InventoryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure;

public class IMDbContext:DbContext
{
    public IMDbContext(DbContextOptions<IMDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products {get; set;} 
    public DbSet<Purchase> Purchases {get; set;} 
    public DbSet<Sale> Sales {get; set;} 
    public DbSet<Stock> Stocks {get; set;} 


}