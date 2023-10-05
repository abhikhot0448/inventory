using dhanman.money.Application.Abstractions.Messaging;

namespace dhanman.money.Application.Features.BillStatuses.Events;

public class BillStatusCreatedEvent : IEvent
{
    public BillStatusCreatedEvent(Guid billStatusId) => BillStatusId = billStatusId;


   public Guid BillStatusId { get;  }

}
