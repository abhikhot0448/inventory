using dhanman.money.Application.Abstractions.Messaging;

namespace dhanman.money.Application.Features.BillHeaders.Events;

public class BillHeaderCreatedEvent : IEvent
{
    public BillHeaderCreatedEvent(Guid billHeaderId) => BillHeaderId = billHeaderId;

    public Guid BillHeaderId { get; }
}
