using B2aTech.CrossCuttingConcern.Core.Abstractions;
using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace dhanman.money.Domain.Entities.BillDetails;

public class BillDetail : Entity, IAuditableEntity, ISoftDeletableEntity
{

    public BillDetail(Guid id ,Guid billHeaderId, string name, string description, decimal price, int quantity, decimal amount)
    {
        Id = id;
        BillHeaderId = billHeaderId;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        Amount = amount;
    }
    public BillDetail() { }



    public Guid BillHeaderId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public decimal Amount { get; private set; }
    public Guid CreatedBy { get; protected set; }
    public Guid? ModifiedBy { get; protected set; }
    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool IsDeleted { get; }
}
