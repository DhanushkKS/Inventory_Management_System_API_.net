namespace InventoryManagementSystem.Domain.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public DateOnly CreatedAt { get; set; }
}