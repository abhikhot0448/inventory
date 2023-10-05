using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Vendors;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.Vendors.Queries;

public sealed class GetVendorByIdQueryHandler : IQueryHandler<GetVendorByIdQuery, Result<VendorResponse>>
{
    private readonly IApplicationDbContext _dbContext;


    public GetVendorByIdQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<Result<VendorResponse>> Handle(GetVendorByIdQuery request, CancellationToken cancellationToken) =>
        await Result.Success(request)
            .Ensure(query => query.VendorId != Guid.Empty, Errors.General.EntityNotFound)
            .Bind(query =>
                _dbContext.Set<Vendor>().AsNoTracking()
                    .Where(e => e.Id == request.VendorId)
                    .Select(e => new VendorResponse(
                        e.Id,
                        e.FirstName,
                        e.LastName,
                        e.Email))
                    .FirstOrDefaultAsync(cancellationToken))
            .Ensure(response => response != null, Errors.General.EntityNotFound);
}
