using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Repositories;

public interface IStockRepository
{
    List<Stock> GetAll();
    Stock GetById(int id);
    Stock Create(Stock stock);
    Stock GetByProductId(int productId);
}