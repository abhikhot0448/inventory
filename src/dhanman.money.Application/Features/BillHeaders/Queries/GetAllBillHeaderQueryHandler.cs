using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.BillHeaders;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.BillHeaders;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.BillHeaders.Queries;

public class GetAllBillHeaderQueryHandler : IQueryHandler<GetAllBillHeadersQuery, Result<BillHeaderListResponce>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetAllBillHeaderQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<Result<BillHeaderListResponce>> Handle(GetAllBillHeadersQuery request, CancellationToken cancellationToken)
    {
        return await Result.Success(request)
            .Ensure(query => query.Clientid != Guid.Empty, Errors.General.EntityNotFound)
            .Bind(async query =>
            {
                var billHeaders = await _dbContext.Set<BillHeader>()
                    .AsNoTracking()
                    .Where(e => e.ClientId == query.Clientid)
                    .Select(e => new BillHeaderResponce(
                        e.Id,
                        e.BillPaymentId,
                        e.BillNumber,
                        e.CoaId,
                        e.BillDate,
                        e.VendorId,
                        e.DueDate,
                        e.PaymentTerm,
                        e.Tax,
                        e.Note,
                        e.Currency,
                        e.Discount
                        ))
                    .ToListAsync(cancellationToken);

                var billheaderlistResponse = new BillHeaderListResponce(billHeaders);

                return billheaderlistResponse;
            });
    }
}
