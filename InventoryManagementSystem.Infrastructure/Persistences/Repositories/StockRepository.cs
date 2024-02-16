using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Infrastructure.Persistences.Repositories;

public class StockRepository : IStockRepository
{
    private readonly IMDbContext _dbContext;
    // private IProductRepository _productRepositoryImplementation;

    public StockRepository(IMDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Stock> GetAll()
    {
        return _dbContext.Stocks.ToList();
    }

    public Stock GetById(int id)
    {
        return _dbContext.Stocks.FirstOrDefault(p => p.Id == id);
    }

    public Stock Create(Stock stock)
    {
        //Create purchase and save to purchase table
        var isStockExists = _dbContext.Stocks.SingleOrDefault(s => s.Id == stock.Id);
       // var isExist = _dbContext.Purchases.SingleOrDefault(i => i.InvoiceNumber == Stock.InvoiceNumber);
        if (isStockExists == null)
        {
            _dbContext.Stocks.Add(stock);
            _dbContext.SaveChanges();
            //Save data Stock table
            if (isStockExists != null)
            {
                isStockExists.Quantity += stock.Quantity;
                isStockExists.ModifiedDate = DateTime.Now;
            }

            _dbContext.SaveChanges();
            return stock;
        }
        throw new Exception("Already exists"); //if some bug happens, refer this

    }

    public Stock GetByProductId(int productId)
    {
        var stock = _dbContext.Stocks.SingleOrDefault(s => s.ProductId == productId);
        if (stock == null) throw new Exception("Stock doesn't exist");
        if (stock.Quantity!=0)
        {
            return stock;
        }

        throw new Exception("Stock doesn't exist");
    }
}