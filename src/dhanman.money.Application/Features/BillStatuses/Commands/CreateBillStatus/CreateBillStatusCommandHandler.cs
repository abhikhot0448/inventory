using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.BillStatuses.Events;
using dhanman.money.Domain.Abstarctions;
using dhanman.money.Domain.Entities.BillStatuses;
using MediatR;

namespace dhanman.money.Application.Features.BillStatuses.Commands.CreateBillStatus;

public class CreateBillStatusCommandHandler : ICommandHandler<CreateBillStatusCommand, Result<EntityCreatedResponse>>
{
    #region Properties

    private readonly IBillStatusRepository _billStatusRepository;
    private readonly IMediator _mediator;
    #endregion

    #region Constructor
    public CreateBillStatusCommandHandler(IBillStatusRepository billStatusRepository, IMediator mediator)
    {
        _billStatusRepository = billStatusRepository;
        _mediator = mediator;
    }
    #endregion

    #region Methods

    public async Task<Result<EntityCreatedResponse>> Handle(CreateBillStatusCommand request, CancellationToken cancellationToken)
    {
        var billStatus = new BillStatus(request.BillStatusId, request.ClientId, request.Name);

        _billStatusRepository.Insert(billStatus);

        await _mediator.Publish(new BillStatusCreatedEvent(billStatus.Id), cancellationToken);

        return Result.Success(new EntityCreatedResponse(billStatus.Id));

    }

    #endregion

}
