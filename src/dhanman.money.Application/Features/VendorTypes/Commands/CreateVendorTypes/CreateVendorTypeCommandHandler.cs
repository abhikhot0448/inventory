using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.VendorTypes.Events;
using dhanman.money.Domain.Abstarctions;
using dhanman.money.Domain.Entities.VendorTypes;
using MediatR;

namespace dhanman.money.Application.Features.VendorTypes.Commands.CreateVendorTypes;

public class CreateVendorTypeCommandHandler : ICommandHandler<CreateVendorTypeCommand, Result<EntityCreatedResponse>>
{
    private readonly IVendorTypeRepository _vendorTypeRepository;
    private readonly IMediator _mediator;

    public CreateVendorTypeCommandHandler(
        IVendorTypeRepository vendorTypeRepository,
        IMediator mediator)
    {
        _vendorTypeRepository = vendorTypeRepository;
        _mediator = mediator;
    }

    public async Task<Result<EntityCreatedResponse>> Handle(CreateVendorTypeCommand request, CancellationToken cancellationToken)
    {
        var vendorType = new VendorType(request.Id, request.ClientId, request.Name, request.Description, Guid.NewGuid());

        _vendorTypeRepository.Insert(vendorType);

        await _mediator.Publish(new VendorTypeCreatedEvent(vendorType.Id), cancellationToken);

        return Result.Success(new EntityCreatedResponse(vendorType.Id));
    }
}
