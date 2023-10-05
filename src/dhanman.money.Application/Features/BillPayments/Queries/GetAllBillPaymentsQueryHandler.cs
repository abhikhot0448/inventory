using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.BillPayments;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.BillPayments;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.BillPayments.Queries;

public class GetAllBillPaymentsQueryHandler : IQueryHandler<GetAllBillPaymentsQuery, Result<BillPaymentListResponse>>
             
{
    #region Properties 

    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructor

    public GetAllBillPaymentsQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methods

    public async Task<Result<BillPaymentListResponse>> Handle(GetAllBillPaymentsQuery request, CancellationToken cancellationToken)
    {
        return await Result.Success(request)
              .Ensure(query => query != null, Errors.General.EntityNotFound)
              .Bind(async query =>
              {
                  var billPayment = await _dbContext.Set<BillPayment>()
                  .AsNoTracking()
                  .Select(e => new BillPaymentResponse(
                          e.Id,
                          e.ClientId,
                          e.Amount,
                          e.BillHeaderId,
                          e.TransactionId,
                          e.COAId,
                          e.CreatedOnUtc
                      ))
                  .ToListAsync(cancellationToken);

                  var listResponse = new BillPaymentListResponse(billPayment);

                  return listResponse;
              });
    }
    #endregion
}
