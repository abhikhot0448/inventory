using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.BillPayments;

namespace dhanman.money.Application.Features.BillPayments.Queries;

public class GetAllBillPaymentsQuery : ICacheableQuery<Result<BillPaymentListResponse>>
{
    #region Constructor

    public GetAllBillPaymentsQuery()
    {

    }
    #endregion

    #region Methods 

    public string GetCacheKey() => string.Format(CacheKeys.BillPayments.BillPaymentList, "user");
    #endregion
}
