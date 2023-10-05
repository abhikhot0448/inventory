using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.BillHeaders.Events;
using dhanman.money.Domain.Abstarctions;
using dhanman.money.Domain.Entities.BillHeaders;
using MediatR;

namespace dhanman.money.Application.Features.BillHeaders.Commands.CreateBillHeaders;

public class CreateBillHeaderCommandHandler : ICommandHandler<CreateBillHeaderCommand, Result<EntityCreatedResponse>>
{

    private readonly IBillHeaderRepositroy _billHeaderRepositroy;
    private readonly IMediator _mediator;

    public CreateBillHeaderCommandHandler(
        IBillHeaderRepositroy billHeaderRepositroy,
        IMediator mediator)
    {
        _billHeaderRepositroy = billHeaderRepositroy;
        _mediator = mediator;
    }

    public async Task<Result<EntityCreatedResponse>> Handle(CreateBillHeaderCommand request, CancellationToken cancellationToken)
    {
        var billHeader = new BillHeader(request.BillHeaderId, request.CoaId, request.ClientId, request.BillPaymentId, request.BillNumber, request.DueDate, request.BillDate, request.BillStatusId, request.VendorId, request.PaymentTerm, request.Tax, request.Note, request.Currency, request.TotalAmount, request.Discount);

        _billHeaderRepositroy.Insert(billHeader);

        await _mediator.Publish(new BillHeaderCreatedEvent(billHeader.Id), cancellationToken);

        return Result.Success(new EntityCreatedResponse(billHeader.Id));
    }

}
