using dhanman.money.Application.Abstractions.Messaging;
namespace dhanman.money.Application.Features.BillDetails.Events;

public class BillDetailCreatedEvent : IEvent
{
    public BillDetailCreatedEvent(Guid billDeatilId) => BillDetailId = billDeatilId;

    public Guid BillDetailId { get; }

}
