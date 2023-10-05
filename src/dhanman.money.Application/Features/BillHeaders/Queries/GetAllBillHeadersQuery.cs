using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.BillHeaders;

namespace dhanman.money.Application.Features.BillHeaders.Queries;

public class GetAllBillHeadersQuery : ICacheableQuery<Result<BillHeaderListResponce>>
{
    public GetAllBillHeadersQuery(Guid clientId) => Clientid = clientId;


    public Guid Clientid;

    public string GetCacheKey() => string.Format(CacheKeys.BillHeaders.BilllHeaderList, "user", Clientid);
}
