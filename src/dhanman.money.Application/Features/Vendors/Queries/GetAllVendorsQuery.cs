using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.BillHeaders;
using dhanman.money.Application.Contracts.Vendors;

namespace dhanman.money.Application.Features.Vendors.Queries
{
    public class GetAllVendorsQuery : ICacheableQuery<Result<VendorListResponse>>
    {
        public GetAllVendorsQuery(Guid clientId) => Clientid = clientId;


        public Guid Clientid;

        public string GetCacheKey() => string.Format(CacheKeys.Vendors.vendorList, "user", Clientid);
    }
}
