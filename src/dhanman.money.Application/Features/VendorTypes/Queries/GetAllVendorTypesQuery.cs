using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.VendorTypes;

namespace dhanman.money.Application.Features.VendorTypes.Queries;

public class GetAllVendorTypesQuery : ICacheableQuery<Result<VendorTypeListResponse>>
{
    public GetAllVendorTypesQuery()
    {

    }

    public string GetCacheKey() => string.Format(CacheKeys.VendorTypes.vendorTypeList , "user");

}
