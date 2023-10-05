using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.BillDetails;
using dhanman.money.Domain.Entities.BillDetails;

namespace dhanman.money.Application.Features.BillDetails.Queries;

public sealed class GetBillDetailByIdQuery : ICacheableQuery<Result<BillDetailResponce>>
{
    public GetBillDetailByIdQuery(Guid billDetailId)
    {
        BillDetailId = billDetailId;
    }

    public Guid BillDetailId { get; }

    public string GetCacheKey() => string.Format(CacheKeys.BillDetails.BillDetailById, "user", BillDetailId);
}

