namespace Dhanman.Sales.Application.Contracts.BillPayments
{
    public class CreateBillPaymentRequest
    {
        #region Properties 

        public Guid UserId { get; }
        public Guid ClientId { get; }
        public decimal Amount { get; private set; }
        public Guid BillHeaderId { get; private set; }
        public Guid TransactionId { get; private set; }
        public Guid COAId { get; private set; }


        #endregion

        #region Constructor

        public CreateBillPaymentRequest(Guid userId, Guid clientId, decimal amount, Guid billHeaderId, Guid transactionId, Guid cOAId)
        {
            UserId = userId;
            ClientId = clientId;
            Amount = amount;
            BillHeaderId = billHeaderId;
            TransactionId = transactionId;
            COAId = cOAId;
        }

        //public CreateBillPaymentRequest() => Amount = 0;
        #endregion
    }
}
