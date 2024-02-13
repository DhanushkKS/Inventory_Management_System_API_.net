namespace InventoryManagementSystem.Domain.Entities;

public class Product:BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public string Category { get; set; } = String.Empty;
    public float Price { get; set; }
    public string ProductDetails { get; set; } = String.Empty;
    
}