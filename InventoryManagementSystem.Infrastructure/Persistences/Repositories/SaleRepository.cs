using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Infrastructure.Persistences.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly IMDbContext _dbContext;
    // private IProductRepository _productRepositoryImplementation;

    public SaleRepository(IMDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Sale> GetAll()
    {
        return _dbContext.Sales.ToList();
    }

    public Sale GetById(int id)
    {
        return _dbContext.Sales.FirstOrDefault(p => p.Id == id);
    }

    public Sale Create(Sale sale)
    {
        //Create purchase and save to purchase table
        var isStockExists = _dbContext.Stocks.SingleOrDefault(s => s.ProductId == sale.ProductId);
        var isExist = _dbContext.Purchases.SingleOrDefault(i => i.InvoiceNumber == sale.InvoiceNumber);
        if (isExist == null && isStockExists != null)
        {
            _dbContext.Sales.Add(sale);
            _dbContext.SaveChanges();
            //Save data Stock table
            isStockExists.Quantity -= sale.Quantity;
            isStockExists.ModifiedDate = DateTime.Now;
            _dbContext.SaveChanges();
            return sale;
        }
        throw new Exception("Already exists"); //if some bug happens, refer this

    }
}