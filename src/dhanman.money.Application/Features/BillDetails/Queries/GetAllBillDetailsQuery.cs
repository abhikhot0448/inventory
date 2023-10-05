using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.BillDetails;

namespace dhanman.money.Application.Features.BillDetails.Queries;

public sealed class GetAllBillDetailsQuery : ICacheableQuery<Result<BillDetailListResponce>>
{
    public GetAllBillDetailsQuery(Guid billHeaderId) => BillHeaderId = billHeaderId;

    public Guid BillHeaderId;
    public string GetCacheKey() => string.Format(CacheKeys.BillDetails.BilllDetailList, "user", BillHeaderId);


}

