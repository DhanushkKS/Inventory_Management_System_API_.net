namespace InventoryManagementSystem.Domain.Entities;

public class Stock : BaseEntity
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime ModifiedDate { get; set; }
}