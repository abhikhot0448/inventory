using dhanman.money.Application.Abstractions.Messaging;

namespace dhanman.money.Application.Features.Bills.Events;

public class BillCreatedEvent : IEvent
{
    #region Properties

    public Guid BillHeaderId;

    #endregion

    #region Constructor
    public BillCreatedEvent(Guid id) => BillHeaderId = id;

    #endregion

}

