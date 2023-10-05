namespace dhanman.money.Application.Contracts.BillHeaders;

public class CreateBillHeaderRequest
{

    public CreateBillHeaderRequest() { }
    
    public Guid CoaId { get; set; }
    public string BillNumber { get; set; }
    public DateTime BillDate { get; set; }
    public int PaymentTerm { get; set; }
    public Guid BillStatusId { get; set; }
    public Guid VendorId { get; set; }
    public decimal Discount { get; set; }
    public Guid BillPaymentId { get; set; }
    public DateTime DueDate { get; set; }
    public Guid ClientId { get; set; }
    public Guid UserId { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Tax { get;  set; }
    public string Note { get;  set; }
    public string Currency { get; set; }

}
