using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;

namespace dhanman.money.Application.Features.VendorTypes.Commands.CreateVendorTypes;

public sealed class CreateVendorTypeCommand : ICommand<Result<EntityCreatedResponse>>
{
    public CreateVendorTypeCommand(Guid id, Guid clientId, string name, string description)
    {
        Id = id;
        ClientId = clientId;
        Name = name;
        Description = description;
    }

    public Guid Id { get; private set; }
    public Guid ClientId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
}
