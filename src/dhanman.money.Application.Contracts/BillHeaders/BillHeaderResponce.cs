namespace dhanman.money.Application.Contracts.BillHeaders;

public class BillHeaderResponce
{


    public BillHeaderResponce(Guid id, Guid billPaymentId, string billNumber, Guid coaId, DateTime billDate, Guid vendorId, DateTime dueDate, int? paymentTerm, decimal tax, string note, string currency, decimal discount)
    {
        Id = id;
        BillPaymentId = billPaymentId;
        BillNumber = billNumber;
        CoaId = coaId;
        BillDate = billDate;
        VendorId = vendorId;
        DueDate = dueDate;
        PaymentTerm = paymentTerm;
        Tax = tax;
        Note = note;
        Currency = currency;
        Discount = discount;
    }

    public Guid Id { get; }
    public Guid BillPaymentId { get; private set; }
    public decimal Discount { get; private set; }
    public string BillNumber { get; private set; }
    public string Currency { get; private set; }
    public Guid CoaId { get; private set; }
    public DateTime BillDate { get; private set; }
    public int? PaymentTerm { get; private set; }
    public Guid BillStatusId { get; private set; }
    public Guid VendorId { get; private set; }
    public DateTime DueDate { get; private set; }
    public decimal Tax { get; private set; }
    public string Note { get; private set; }

}
