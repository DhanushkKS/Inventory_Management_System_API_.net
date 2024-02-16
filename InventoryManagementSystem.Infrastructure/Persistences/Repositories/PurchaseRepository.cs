using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Infrastructure;

public class PurchaseRepository : IPurchaseRepository
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
        //Create purchase and save to purchase table
        var isExist = _dbContext.Purchases.SingleOrDefault(i => i.InvoiceNumber == purchase.InvoiceNumber);
        if (isExist != null) throw new Exception("Already exists"); //if some bug happens, refer this
        _dbContext.Purchases.Add(purchase);
        _dbContext.SaveChanges();
        
        //Save data Stock table
        var isStockExists = _dbContext.Stocks.SingleOrDefault(s => s.ProductId == purchase.ProductId);
        if (isStockExists == null)
        {
            Stock stock = new Stock()
            {
                CreatedAt = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ProductId = purchase.ProductId,
                Quantity = purchase.Quantity
            };
            _dbContext.Stocks.Add(stock);
            _dbContext.SaveChanges();
        }
        else
        {
            isStockExists.Quantity += purchase.Quantity;
            isStockExists.ModifiedDate=DateTime.Now;
            _dbContext.SaveChanges();
        }

        return purchase;
    }
}