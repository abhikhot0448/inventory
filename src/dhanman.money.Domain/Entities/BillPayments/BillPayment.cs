using B2aTech.CrossCuttingConcern.Core.Abstractions;
using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace dhanman.money.Domain.Entities.BillPayments;

public class BillPayment : Entity, IAuditableEntity, ISoftDeletableEntity
{

    #region Properties
    public Guid ClientId { get; private set; }
    public decimal Amount { get; private set; }
    public Guid BillHeaderId { get; private set; }
    public Guid TransactionId { get; private set; }
    public Guid COAId { get; private set; }
    public Guid CreatedBy { get; protected set; }
    public Guid? ModifiedBy { get; protected set; }
    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool IsDeleted { get; }
    #endregion

    #region Constructor
    public BillPayment(
        Guid id, Guid clientId, decimal amount, Guid billHeaderId, Guid transactionId,
        Guid cOAId, Guid createdBy)
    {
        Id = id;
        ClientId = clientId;
        Amount = amount;
        BillHeaderId = billHeaderId;
        TransactionId = transactionId;
        COAId = cOAId;
        CreatedBy = createdBy;
        CreatedOnUtc = DateTime.UtcNow;
    }

    public BillPayment() { }
    #endregion

}
