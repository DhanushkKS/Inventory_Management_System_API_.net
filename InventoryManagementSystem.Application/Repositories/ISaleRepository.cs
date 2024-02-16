using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Repositories;

public interface ISaleRepository
{
    List<Sale> GetAll();
    Sale GetById(int id);
    Sale Create(Sale sale);
}