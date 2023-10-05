namespace dhanman.money.Application.Contracts.Bill;

public class CreateBillRequest
{

    #region Constructor
    public CreateBillRequest(Guid coaId, Guid clientId, Guid billPaymentId, string billNumber, DateTime dueDate, DateTime billDate, Guid billStatusId, Guid vendorId, int? paymentTerm, decimal tax, string note, string currency, decimal totalAmount, decimal discount, List<BillLine> lines)
    {
        CoaId = coaId;
        ClientId = clientId;
        BillPaymentId = billPaymentId;
        BillNumber = billNumber;
        DueDate = dueDate;
        BillDate = billDate;
        BillStatusId = billStatusId;
        VendorId = vendorId;
        PaymentTerm = paymentTerm;
        Tax = tax;
        Note = note;
        Currency = currency;
        TotalAmount = totalAmount;
        Discount = discount;
        Lines = lines;

    }

    public CreateBillRequest() { }
    #endregion

    #region Properties
    public Guid ClientId { get; set; }
    public Guid VendorId { get; set; }
    public Guid CoaId { get; set; }
    public decimal Discount { get; set; }
    public string BillNumber { get; set; }
    public string Currency { get; set; }
    public DateTime BillDate { get; set; }
    public int? PaymentTerm { get; set; }
    public Guid BillStatusId { get; set; }
    public Guid BillPaymentId { get; set; }
    public DateTime DueDate { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Tax { get; set; }
    public string Note { get; set; }
    public List<BillLine> Lines { get; set; }
    #endregion

}
