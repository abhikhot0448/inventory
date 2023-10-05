using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Vendors;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.Vendors.Queries;

public class GetAllVendorsQueryHandler : IQueryHandler<GetAllVendorsQuery, Result<VendorListResponse>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetAllVendorsQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<Result<VendorListResponse>> Handle(GetAllVendorsQuery request, CancellationToken cancellationToken)
    {
        return await Result.Success(request)
            .Ensure(query => query.Clientid != Guid.Empty, Errors.General.EntityNotFound)
            .Bind(async query =>
            {
                var vendors = await _dbContext.Set<Vendor>()
                    .AsNoTracking()
                    .Where(e => e.ClientId == query.Clientid)
                    .Select(e => new VendorResponse(
                        e.Id,
                        e.FirstName,
                        e.LastName,
                        e.Email
                        ))
                    .ToListAsync(cancellationToken);

                var vendorListResponse = new VendorListResponse(vendors);

                return vendorListResponse;
            });
    }
}
