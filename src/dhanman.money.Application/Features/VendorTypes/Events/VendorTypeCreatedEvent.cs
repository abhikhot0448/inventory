using dhanman.money.Application.Abstractions.Messaging;

namespace dhanman.money.Application.Features.VendorTypes.Events;

internal class VendorTypeCreatedEvent : IEvent
{
    public VendorTypeCreatedEvent(Guid vendorTypeId) => VendorTypeId = vendorTypeId;

    public Guid VendorTypeId { get; set; }
}
