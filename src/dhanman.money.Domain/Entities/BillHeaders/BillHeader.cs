using B2aTech.CrossCuttingConcern.Core.Abstractions;
using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace dhanman.money.Domain.Entities.BillHeaders;

public class BillHeader : Entity, IAuditableEntity, ISoftDeletableEntity
{
    public BillHeader(Guid id, Guid coaId, Guid clientId, Guid billPaymentId, string billNumber, DateTime dueDate, DateTime billDate, Guid billStatusId, Guid vendorId, int? paymentTerm, decimal tax, string note, string currency, decimal totalAmount, decimal discount)
    {
        Id = id;
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

    }
    public BillHeader() { }

    public Guid ClientId { get; private set; }
    public Guid VendorId { get; private set; }
    public Guid CoaId { get; private set; }
    public decimal Discount { get; private set; }
    public string BillNumber { get; private set; }
    public string Currency { get; private set; }
    public DateTime BillDate { get; private set; }
    public int? PaymentTerm { get; private set; }
    public Guid BillStatusId { get; private set; }
    public Guid BillPaymentId { get; private set; }
    public DateTime DueDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public decimal Tax { get; private set; }
    public string Note { get; private set; }
    public Guid UserId { get; set; }
    public DateTime CreatedOnUtc { get; }
    public Guid CreatedBy { get; }
    public Guid? ModifiedBy { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool IsDeleted { get; }
}
