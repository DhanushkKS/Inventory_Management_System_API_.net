namespace InventoryManagementSystem.Domain.Entities;

public class Purchase:BaseEntity
{
    public int  ProductId { get; set; }
    public int Quantity { get; set; }
    public string SupplierName { get; set; } = String.Empty;
    public float InvoiceAmount { get; set; }
    public string InvoiceNumber { get; set; }  = String.Empty;
}