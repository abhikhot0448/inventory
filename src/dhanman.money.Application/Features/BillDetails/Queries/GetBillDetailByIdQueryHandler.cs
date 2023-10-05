using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.BillDetails;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.BillDetails;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.BillDetails.Queries;

public sealed class GetBillDetailByIdQueryHandler : IQueryHandler<GetBillDetailByIdQuery, Result<BillDetailResponce>>
{
    private readonly IApplicationDbContext _dbContext;


    public GetBillDetailByIdQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<Result<BillDetailResponce>> Handle(GetBillDetailByIdQuery request, CancellationToken cancellationToken) =>
        await Result.Success(request)
            .Ensure(query => query.BillDetailId != Guid.Empty, Errors.General.EntityNotFound)
            .Bind(query =>
                _dbContext.Set<BillDetail>().AsNoTracking()
                    .Where(e => e.Id == request.BillDetailId)
                    .Select(e => new BillDetailResponce(
                        e.Id,
                        e.Name,
                        e.BillHeaderId,
                        e.Description,
                        e.Price,
                        e.Quantity,
                        e.Amount))
                    .FirstOrDefaultAsync(cancellationToken))
            .Ensure(response => response != null, Errors.General.EntityNotFound);
}

