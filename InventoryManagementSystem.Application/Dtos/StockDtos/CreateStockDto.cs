namespace InventoryManagementSystem.Application.Dtos.StockDtos;

public class CreateStockDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime ModifiedDate { get; set; }
}