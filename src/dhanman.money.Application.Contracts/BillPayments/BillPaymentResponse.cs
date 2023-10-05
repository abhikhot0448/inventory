namespace dhanman.money.Application.Contracts.BillPayments;

public sealed class BillPaymentResponse
{
    #region Properties
    public Guid Id { get; }
    public Guid ClientId { get; }
    public decimal Amount { get; set; }
    public Guid BillHeaderId { get; set; }
    public Guid TransactionId { get; set; }
    public Guid COAId { get; set; }
    public DateTime CreatedOnUtc { get; }

    #endregion

    #region Constructor
    public BillPaymentResponse(
     Guid id,
     Guid clientId,
     decimal amount,
     Guid billHeaderId,
     Guid transactionId,
     Guid cOAId,
     DateTime createdOnUtc)
    {
        Id = id;
        ClientId = clientId;
        Amount = amount;
        BillHeaderId = billHeaderId;
        TransactionId = transactionId;
        COAId = cOAId;
        CreatedOnUtc = createdOnUtc;
    }
    #endregion
}
