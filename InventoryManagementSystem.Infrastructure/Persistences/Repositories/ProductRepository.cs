using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Infrastructure;

public class ProductRepository:IProductRepository
{
    private readonly IMDbContext _dbContext;
    // private IProductRepository _productRepositoryImplementation;

    public ProductRepository(IMDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Product> GetAllProducts()
    {
        return _dbContext.Products.ToList();
    }

    public Product GetProductById(int id)
    {
        return _dbContext.Products.FirstOrDefault(p => p.Id == id);
    }

    public Product CreateProduct(Product product)
    {
        var isExist =
            _dbContext.Products.SingleOrDefault(p => p.Name.ToLower().Trim() == product.Name.ToLower().Trim());
        if (isExist==null)
        {
            product.CreatedAt=DateTime.Now;
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }
        throw new Exception("Product already exists");
    }
}