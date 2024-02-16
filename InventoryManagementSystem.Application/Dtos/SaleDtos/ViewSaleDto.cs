namespace InventoryManagementSystem.Application.Dtos.SaleDtos;

public class ViewSaleDto
{
    public String InvoiceNumber { get; set; }
    public string CustomerName { get; set; }
    public string MobileNumber { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public float Total { get; set; }
}