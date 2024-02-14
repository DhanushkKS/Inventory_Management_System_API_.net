namespace InventoryManagementSystem.Application.Dtos.PurchaseDtos;

public class ViewPurchaseDto
{
    public int Quantity { get; set; }
    public string SupplierName { get; set; } = String.Empty;
    public float InvoiceAmount { get; set; }
    public string InvoiceNumber { get; set; }  = String.Empty;

}