using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.BillStatuses;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.BillStatuses;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.BillStatuses.Queries;

public sealed class GetBillStatusByIdQueryHandler : IQueryHandler<GetBillStatusByIdQuery, Result<BillStatusResponse>>
{

    #region Properties

    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructor

    public GetBillStatusByIdQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methods
    public  async Task<Result<BillStatusResponse>> Handle(GetBillStatusByIdQuery request, CancellationToken cancellationToken) =>
          await Result.Success(request)
           .Ensure(query => query.BillStatusId != Guid.Empty,Errors.General.EntityNotFound)
            .Bind(query =>
                _dbContext.Set<BillStatus>().AsNoTracking()
                    .Where(e => e.Id == request.BillStatusId)
                    .Select(e => new BillStatusResponse(
                        e.Id,
                        e.Name
                      ))
                    .FirstOrDefaultAsync(cancellationToken))
            .Ensure(response => response != null, Errors.General.EntityNotFound);

    #endregion

}
