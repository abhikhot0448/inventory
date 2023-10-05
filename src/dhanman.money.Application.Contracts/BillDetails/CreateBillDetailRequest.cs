namespace dhanman.money.Application.Contracts.BillDetails;

public class CreateBillDetailRequest
{
    public CreateBillDetailRequest() => Name = string.Empty;

    public Guid BillDetailId { get; set; }
    public Guid BillHeaderId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; set; }
}
