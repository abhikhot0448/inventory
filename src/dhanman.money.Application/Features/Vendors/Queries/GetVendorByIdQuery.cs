using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;

using dhanman.money.Application.Contracts.Vendors;

namespace dhanman.money.Application.Features.Vendors.Queries;

public sealed class GetVendorByIdQuery : ICacheableQuery<Result<VendorResponse>>
{
    public GetVendorByIdQuery(Guid vendorId)
    {
        VendorId = vendorId;
    }

    public Guid VendorId { get; }

    public string GetCacheKey() => string.Format(CacheKeys.Vendors.vendorById, "user", VendorId);
}
