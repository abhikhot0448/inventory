using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.VendorTypes;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.VendorTypes;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.VendorTypes.Queries;

public class GetAllVendorTypesQueryHandler : IQueryHandler<GetAllVendorTypesQuery, Result<VendorTypeListResponse>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetAllVendorTypesQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

   

    public async Task<Result<VendorTypeListResponse>> Handle(GetAllVendorTypesQuery request, CancellationToken cancellationToken)
    {
        return await Result.Success(request)
              .Ensure(query => query != null, Errors.General.EntityNotFound)
              .Bind(async query =>
              {
                  var vendorTypes = await _dbContext.Set<VendorType>()
                  .AsNoTracking()
                  .Select(e => new VendorTypeResponse(
                          e.Id,
                          e.ClientId,
                          e.Name,
                          e.Description
                      ))
                  .ToListAsync(cancellationToken);
                  var listResponse = new VendorTypeListResponse(vendorTypes);
                  return listResponse;
              });
    }
}
