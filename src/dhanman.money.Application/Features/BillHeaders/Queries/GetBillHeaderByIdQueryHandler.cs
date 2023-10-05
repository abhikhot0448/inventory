using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.BillHeaders;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.BillHeaders;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.BillHeaders.Queries;

public class GetBillHeaderByIdQueryHandler : IQueryHandler<GetBillHeaderByIdQuery, Result<BillHeaderResponce>>
{
    private readonly IApplicationDbContext _dbContext;


    public GetBillHeaderByIdQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<Result<BillHeaderResponce>> Handle(GetBillHeaderByIdQuery request, CancellationToken cancellationToken) =>
        await Result.Success(request)
            .Ensure(query => query.BillHeadersId != Guid.Empty, Errors.General.EntityNotFound)
            .Bind(query =>
                _dbContext.Set<BillHeader>().AsNoTracking()
                    .Where(e => e.Id == request.BillHeadersId)
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
                    .FirstOrDefaultAsync(cancellationToken))
            .Ensure(response => response != null, Errors.General.EntityNotFound);
}



