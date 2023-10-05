using dhanman.money.Application.Abstractions.Messaging;

namespace dhanman.money.Application.Features.BillPayments.Events
{
    public class BillPaymentCreatedEvent : IEvent
    {
        #region Properties 

        public Guid BillPaymentId { get; }
        #endregion

        #region Constructor

        public BillPaymentCreatedEvent(Guid billPaymentId) => BillPaymentId = billPaymentId;
        #endregion
    }
}
