using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Domain.Entities.Users.Vendors;

namespace dhanman.money.Application.Features.Vendors.Events;

public sealed class VendorCreatedEvent : IEvent
{
    public VendorCreatedEvent(Guid vendrId) => VendorId = vendrId;

    public Guid VendorId { get; }
}
