using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.BillPayments;

namespace dhanman.money.Application.Features.BillPayments.Queries
{
    public class GetBillPaymentByIdQuery : ICacheableQuery<Result<BillPaymentResponse>>
    {
        #region Properties 
        public Guid BillPaymentId { get; }
       
        #endregion

        #region Constructor

        public GetBillPaymentByIdQuery(Guid billPaymentId) => BillPaymentId = billPaymentId;
        #endregion

        #region Methods

        public string GetCacheKey() => string.Format(CacheKeys.BillPayments.BillPaymentById, "user", BillPaymentId);
        #endregion

    }
}
