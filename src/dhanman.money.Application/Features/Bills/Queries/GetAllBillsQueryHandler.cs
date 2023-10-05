using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Bill;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities;
using dhanman.money.Domain.Entities.BillDetails;
using dhanman.money.Domain.Entities.BillHeaders;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.Bills.Queries;

public class GetAllBillsQueryHandler : IQueryHandler<GetAllBillsQuery, Result<BillListResponse>>
{
    #region Properties

    private readonly IApplicationDbContext _dbContext;

    #endregion

    #region Constructor

    public GetAllBillsQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    #endregion

    #region Methods
    public async Task<Result<BillListResponse>> Handle(GetAllBillsQuery request, CancellationToken cancellationToken)
    {
        return await Result.Success(request)
        .Ensure(query => query.Clientid != Guid.Empty, Errors.General.EntityNotFound)
        .Bind(async query =>
        {
            var billHeaders = await _dbContext.Set<BillHeader>()
                .AsNoTracking()
                .Where(bh => bh.ClientId == query.Clientid)
                .Select(bh => new BillResponse(
                    bh.Id,
                    bh.BillPaymentId,
                    bh.BillNumber,
                    bh.CoaId,
                    _dbContext.Set<Vendor>()
                    .Where(vendor => vendor.Id == bh.VendorId)
                    .Select(vendor => vendor.FirstName + " " + vendor.LastName)
                    .FirstOrDefault(),
                    bh.DueDate,
                    bh.BillDate,
                    bh.PaymentTerm,
                    bh.TotalAmount,
                    bh.Currency,
                    bh.BillStatusId,
                    bh.Tax,
                    bh.Discount,
                    bh.Note,
                    _dbContext.Set<BillDetail>()
                       .Where(detail => detail.BillHeaderId == bh.Id)
                       .Select(detail => new BillLine(
                           detail.Name,
                           detail.Description,
                           detail.Price,
                           detail.Quantity,
                           detail.Amount
                           ))
                          .ToList()
                    ))
                .ToListAsync(cancellationToken);

            var billlistResponse = new BillListResponse(billHeaders);

            return billlistResponse;
        });
    }

    #endregion
}

