using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.BillHeaders;

namespace dhanman.money.Application.Features.BillHeaders.Queries;

public class GetBillHeaderByIdQuery : ICacheableQuery<Result<BillHeaderResponce>>
{
    public GetBillHeaderByIdQuery(Guid billHeaderId) => BillHeadersId = billHeaderId;
    public Guid BillHeadersId { get; }
    public string GetCacheKey() => string.Format(CacheKeys.BillHeaders.BillHeaderById, "user", BillHeadersId);
}
