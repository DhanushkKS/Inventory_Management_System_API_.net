namespace InventoryManagementSystem.Application.Dtos.ProductDtos;

public class ViewProductDto
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public float Price { get; set; }
    public string ProductDetails { get; set; } = string.Empty;

}