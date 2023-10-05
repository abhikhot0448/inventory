using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;

namespace dhanman.money.Application.Features.CreateBillPayment.Commands.CreateBillPayment
{
    public class CreateBillPaymentCommand : ICommand<Result<EntityCreatedResponse>>
    {
        #region Properties
        public Guid ClientId { get; }
        public Guid BillPaymentId { get; }
        public decimal Amount { get; }
        public Guid BillHeaderId { get; }
        public Guid TransactionId { get; }
        public Guid COAId { get; }
        #endregion 

        #region Constructor
        public CreateBillPaymentCommand(Guid billPaymentId, Guid clientId, decimal amount, Guid billHeaderId, Guid transactionId, Guid cOaId)
        {
            BillPaymentId = billPaymentId;
            ClientId = clientId;
            Amount = amount;
            BillHeaderId = billHeaderId;
            TransactionId = transactionId;
            COAId = cOaId;
        }
        #endregion


    }
}
