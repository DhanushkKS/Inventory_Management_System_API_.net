using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Repositories;

public interface IPurchaseRepository
{
    List<Purchase> GetAll();
    Purchase GetById(int id);
    Purchase Create(Purchase purchase);
}