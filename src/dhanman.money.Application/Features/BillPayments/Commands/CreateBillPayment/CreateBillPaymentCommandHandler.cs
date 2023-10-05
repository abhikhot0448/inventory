using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.BillPayments.Events;
using dhanman.money.Application.Features.CreateBillPayment.Commands.CreateBillPayment;
using dhanman.money.Domain.Abstarctions;
using dhanman.money.Domain.Entities.BillPayments;
using MediatR;

namespace dhanman.money.Application.Features.BillPayments.Commands
{
    public class CreateBillPaymentCommandHandler : ICommandHandler<CreateBillPaymentCommand, Result<EntityCreatedResponse>>
    {
        #region Properties 

        private readonly IBillPaymentRepository _billPaymentRepository;

        private readonly IMediator _mediator;
        #endregion

        #region Constructor

        public CreateBillPaymentCommandHandler(IBillPaymentRepository billPaymentRepository, IMediator mediator)
        {
            _billPaymentRepository = billPaymentRepository;
            _mediator = mediator;
        }
        #endregion

        #region Methods

        public async Task<Result<EntityCreatedResponse>> Handle(CreateBillPaymentCommand request, CancellationToken cancellationToken)
        {
            var billPayment = new BillPayment(request.BillPaymentId, Guid.NewGuid(), request.Amount, request.BillHeaderId, request.TransactionId, request.COAId, request.ClientId);
            _billPaymentRepository.Insert(billPayment);
            await _mediator.Publish(new BillPaymentCreatedEvent(billPayment.Id), cancellationToken);
            return Result.Success(new EntityCreatedResponse(billPayment.Id));
        }
        #endregion
    }
}
