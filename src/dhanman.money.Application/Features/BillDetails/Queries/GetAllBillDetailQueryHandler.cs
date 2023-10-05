using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.BillDetails;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.BillDetails;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.BillDetails.Queries;

public class GetAllBillDetailQueryHandler : IQueryHandler<GetAllBillDetailsQuery, Result<BillDetailListResponce>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetAllBillDetailQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<Result<BillDetailListResponce>> Handle(GetAllBillDetailsQuery request, CancellationToken cancellationToken)
    {
        return await Result.Success(request)
            .Ensure(query => query != null , Errors.General.EntityNotFound)
            .Bind(async query =>
            {
                var invoiceHeaders = await _dbContext.Set<BillDetail>()
                    .AsNoTracking()
                    .Where(e => e.BillHeaderId != null)
                    .Select(e => new BillDetailResponce(
                        e.Id,
                        e.Name,
                        e.BillHeaderId,
                        e.Description,
                        e.Price,
                        e.Quantity,
                        e.Amount))
                    .ToListAsync(cancellationToken);

                var listResponse = new BillDetailListResponce(invoiceHeaders);

                return listResponse;
            });
         }
}
