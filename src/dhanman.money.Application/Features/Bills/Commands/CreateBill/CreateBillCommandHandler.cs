using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Bill;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.Bills.Events;
using dhanman.money.Domain.Abstarctions;
using dhanman.money.Domain.Entities.BillDetails;
using dhanman.money.Domain.Entities.BillHeaders;
using MediatR;

namespace dhanman.money.Application.Features.Bills.Commands.CreateBill;

public class CreateBillCommandHandler : ICommandHandler<CreateBillCommand, Result<EntityCreatedResponse>>
{
    #region Propertries

    private readonly IBillDetailRepository _billDetailRepository;
    private readonly IBillHeaderRepositroy _billHeaderRepositroy;
    private readonly IMediator _mediator;
    #endregion

    #region Constructors
    public CreateBillCommandHandler(
       IBillHeaderRepositroy billHeaderRepositroy,
       IBillDetailRepository billDetailRepository,
       IMediator mediator)
    {
        _billHeaderRepositroy = billHeaderRepositroy;
        _billDetailRepository = billDetailRepository;
        _mediator = mediator;
    }
    #endregion

    #region Methods

    public async Task<Result<EntityCreatedResponse>> Handle(CreateBillCommand request, CancellationToken cancellationToken)
    {

        var billHeader = GetBillHeaderEntity(request);
        _billHeaderRepositroy.Insert(billHeader);

        foreach (var item in request.Lines)
        {
            var billDetail = GetBillDetailEntity(item, request.BillId);
            _billDetailRepository.Insert(billDetail);
        }

        await _mediator.Publish(new BillCreatedEvent(billHeader.Id), cancellationToken);
        return Result.Success(new EntityCreatedResponse(billHeader.Id));

    }

    private BillDetail GetBillDetailEntity(BillLine line, Guid billId)
    {
        return new BillDetail(Guid.NewGuid(), billId, line.Name, line.Description, line.Price, line.Quantity, line.Amount);
    }

    private BillHeader GetBillHeaderEntity(CreateBillCommand request)
    
    {
        return new BillHeader(
            request.BillId, request.CoaId, request.ClientId, request.BillPaymentId,
            request.BillNumber, request.DueDate, request.BillDate, request.BillStatusId,
            request.VendorId, request.PaymentTerm, request.Tax, request.Note, request.Currency,
            request.TotalAmount, request.Discount);
    }

    #endregion

}

