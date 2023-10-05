using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.VendorTypes;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.VendorTypes;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.VendorTypes.Queries;

internal sealed class GetVendorTypeByIdQueryHandler : IQueryHandler<GetVendorTypeByIdQuery, Result<VendorTypeResponse>>
{
    private readonly IApplicationDbContext _dbContext;


    public GetVendorTypeByIdQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<Result<VendorTypeResponse>> Handle(GetVendorTypeByIdQuery request, CancellationToken cancellationToken) =>
        await Result.Success(request)
            .Ensure(query => query.VendorTypeId != Guid.Empty, Errors.General.EntityNotFound)
            .Bind(query =>
                _dbContext.Set<VendorType>().AsNoTracking()
                    .Where(e => e.Id == request.VendorTypeId)
                    .Select(e => new VendorTypeResponse(
                        e.Id,
                        e.ClientId,
                        e.Name,
                        e.Description
                        ))
                    .FirstOrDefaultAsync(cancellationToken))
            .Ensure(response => response != null, Errors.General.EntityNotFound);
}