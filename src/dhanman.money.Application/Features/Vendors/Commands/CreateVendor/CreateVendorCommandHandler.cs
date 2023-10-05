using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.Vendors.Events;
using dhanman.money.Domain.Abstarctions;
using dhanman.money.Domain.Entities;
using MediatR;

namespace dhanman.money.Application.Features.Vendors.Commands.CreateVendor
{
    public class CreateVendorCommandHandler : ICommandHandler<CreateVendorCommand, Result<EntityCreatedResponse>>
    {

        private readonly IVendorRepository _vendorRepository;
        private readonly IMediator _mediator;

        public CreateVendorCommandHandler(
            IVendorRepository vendorRepository,
            IMediator mediator)
        {
            _vendorRepository = vendorRepository;
            _mediator = mediator;
        }

        public async Task<Result<EntityCreatedResponse>> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = new Vendor(request.VendorId, request.FirstName, request.LastName, request.Email,request.ClientId, Guid.NewGuid());

            _vendorRepository.Insert(vendor);

            await _mediator.Publish(new VendorCreatedEvent(vendor.Id), cancellationToken);

            return Result.Success(new EntityCreatedResponse(vendor.Id));
        }
    }
    
}