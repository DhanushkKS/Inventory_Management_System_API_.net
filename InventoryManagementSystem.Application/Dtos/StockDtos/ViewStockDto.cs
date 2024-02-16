namespace InventoryManagementSystem.Application.Dtos.SaleDtos;

public class ViewStockDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime ModifiedDate { get; set; }
}