using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.VendorTypes;

namespace dhanman.money.Application.Features.VendorTypes.Queries;

public sealed class GetVendorTypeByIdQuery : ICacheableQuery<Result<VendorTypeResponse>>
{

    public GetVendorTypeByIdQuery(Guid vendorTypeId)
    {
        VendorTypeId = vendorTypeId;
    }

    public Guid VendorTypeId { get; }

    public string GetCacheKey() => string.Format(CacheKeys.VendorTypes.vendorTypeById , "VendorTypeId", VendorTypeId);
}