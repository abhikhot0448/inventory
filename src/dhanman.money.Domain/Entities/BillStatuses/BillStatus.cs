using B2aTech.CrossCuttingConcern.Core.Abstractions;
using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace dhanman.money.Domain.Entities.BillStatuses;

public class BillStatus : Entity, IAuditableEntity, ISoftDeletableEntity
{
    #region Constructor

    public BillStatus(Guid id, Guid clientId, string name)
    {
        Id = id;
        CreatedBy = clientId;
        Name = name;
        CreatedOnUtc = DateTime.UtcNow;
    }


    public BillStatus()
    {
        
    }

    #endregion

    #region Properties

    public string Name { get; set; }

    public Guid CreatedBy { get; protected set; }

    public Guid? ModifiedBy { get; protected set; }

    public DateTime CreatedOnUtc { get; }

    public DateTime? ModifiedOnUtc { get; }

    public DateTime? DeletedOnUtc { get; }

    public bool IsDeleted { get; }

    #endregion

}
