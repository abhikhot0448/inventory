using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.BillStatuses;

namespace dhanman.money.Application.Features.BillStatuses.Queries;

public class GetBillStatusByIdQuery : ICacheableQuery<Result<BillStatusResponse>>
{
    public GetBillStatusByIdQuery(Guid billStatusId) 
    {
        BillStatusId = billStatusId;
    }

    public Guid BillStatusId { get; set; }

    public string GetCacheKey() => string.Format(CacheKeys.BillStatuses.BillStatusById, "bill");

}
