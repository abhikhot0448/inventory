using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.BillDetails.Events;
using dhanman.money.Domain.Abstarctions;
using dhanman.money.Domain.Entities.BillDetails;
using MediatR;

namespace dhanman.money.Application.Features.BillDetails.Commands.CreateBillDetails;

public class CreateBillDetailCommandHandler : ICommandHandler<CreateBillDetailCommand, Result<EntityCreatedResponse>>
{
    private readonly IBillDetailRepository _billDetailRepository ;
    private readonly IMediator _mediator;

    public CreateBillDetailCommandHandler(
        IBillDetailRepository billDetailRepository,
        IMediator mediator)
    {
        _billDetailRepository = billDetailRepository;
        _mediator = mediator;
    }

    public async Task<Result<EntityCreatedResponse>> Handle(CreateBillDetailCommand request, CancellationToken cancellationToken)
    {
        var billDetail = new BillDetail(request.BillDetailId, request.BillHeaderId, request.Name, request.Description, request.Price, request.Quantity, request.Amount);

        _billDetailRepository.Insert(billDetail);
       
       


        await _mediator.Publish(new BillDetailCreatedEvent(billDetail.Id), cancellationToken);

        return Result.Success(new EntityCreatedResponse(billDetail.Id));
    }

}
