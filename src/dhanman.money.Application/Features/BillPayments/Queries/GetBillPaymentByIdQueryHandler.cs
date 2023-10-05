using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.BillPayments;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.BillPayments;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.BillPayments.Queries
{
    public class GetBillPaymentByIdQueryHandler : IQueryHandler<GetBillPaymentByIdQuery, Result<BillPaymentResponse>>
    {
        #region Properties 

        private readonly IApplicationDbContext _dbContext;
        #endregion

        #region Constructor

        public GetBillPaymentByIdQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;
        #endregion

        #region Methods

        public async Task<Result<BillPaymentResponse>> Handle(GetBillPaymentByIdQuery request, CancellationToken cancellationToken) =>

            await Result.Success(request)
                .Ensure(query => query.BillPaymentId != Guid.Empty, Errors.General.EntityNotFound)
                .Bind(query =>
                  _dbContext.Set<BillPayment>().AsNoTracking()
                  .Where(e => e.Id == request.BillPaymentId)
                  .Select(e => new BillPaymentResponse(
                      e.Id,
                      e.ClientId,
                      e.Amount,
                      e.BillHeaderId,
                      e.TransactionId,
                      e.COAId,
                      e.CreatedOnUtc
                ))
                  .FirstOrDefaultAsync(cancellationToken))
                .Ensure(response => response != null, Errors.General.EntityNotFound);
        #endregion
    }
}
