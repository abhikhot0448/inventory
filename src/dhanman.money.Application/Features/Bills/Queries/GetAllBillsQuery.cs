using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.Bill;

namespace dhanman.money.Application.Features.Bills.Queries;

public class GetAllBillsQuery
    : ICacheableQuery<Result<BillListResponse>>
{
    #region Properties

    public Guid Clientid;

    #endregion

    #region Constructor
    public GetAllBillsQuery(Guid clientId) => Clientid = clientId;

    #endregion

    #region Methods
    public string GetCacheKey() => string.Format(CacheKeys.Bills.BillList, "user", Clientid);

    #endregion

}

