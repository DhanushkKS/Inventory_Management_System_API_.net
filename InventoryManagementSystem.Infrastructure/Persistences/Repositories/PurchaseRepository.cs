using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Infrastructure;

public class PurchaseRepository:IPurchaseRepository
{
    private readonly IMDbContext _dbContext;
    // private IProductRepository _productRepositoryImplementation;

    public PurchaseRepository(IMDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Purchase> GetAll()
    {
        return _dbContext.Purchases.ToList();
    }

    public Purchase GetById(int id)
    {
        return _dbContext.Purchases.FirstOrDefault(p => p.Id == id);
    }

    public Purchase Create(Purchase purchase)
    {
        _dbContext.Purchases.Add(purchase);
        _dbContext.SaveChanges();
        return purchase;
    }
}