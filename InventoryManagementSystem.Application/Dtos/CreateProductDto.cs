namespace InventoryManagementSystem.Application.Dtos;

public class CreateProductDto
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public float Price { get; set; }
    public string ProductDetails { get; set; } = string.Empty;
}