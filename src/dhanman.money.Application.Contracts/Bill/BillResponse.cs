namespace dhanman.money.Application.Contracts.Bill;

public class BillResponse
{

    #region Constructors
    public BillResponse(Guid id,
            Guid billPaymentId,
            string billNumber,
            Guid coaId,
            string vendorName,
            DateTime dueDate,
            DateTime billDate,
            int? paymentTerm,
            decimal amount,
            string currency,
            Guid billStatusId,
            decimal tax,
            decimal discount,
            string note,
            List<BillLine> lines)
    {
        Id = id;
        BillPaymentId = billPaymentId;
        BillNumber = billNumber;
        CoaId = coaId;
        BillDate = billDate;
        PaymentTerm = paymentTerm;
        VendorName = vendorName;
        DueDate = dueDate;
        Amount = amount;
        Tax = tax;
        Discount = discount;
        Note = note;
        Lines = lines;
        Currency = currency;
        BillStatusId = billStatusId;
    }
    #endregion

    #region Properties
    public Guid Id { get; }
    public Guid BillPaymentId { get; set; }
    public string BillNumber { get; set; }
    public Guid CoaId { get; set; }
    public DateTime BillDate { get; set; }
    public int? PaymentTerm { get; set; }
    public string VendorName { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
    public decimal Tax { get; set; }
    public decimal Discount { get; set; }
    public Guid BillStatusId { get; set; }
    public string Note { get; set; }
    public string Currency { get; set; }
    public List<BillLine> Lines { get; set; }

    #endregion

}
