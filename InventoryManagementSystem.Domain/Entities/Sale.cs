namespace InventoryManagementSystem.Domain.Entities;

public class Sale : BaseEntity
{
    public String InvoiceNo { get; set; }
    public string CustomerName { get; set; }
    public string MobileNumber { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public float Total { get; set; }
}