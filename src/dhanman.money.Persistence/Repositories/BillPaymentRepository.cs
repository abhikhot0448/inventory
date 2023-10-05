using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Domain.Abstarctions;
using dhanman.money.Domain.Entities.BillPayments;

namespace dhanman.money.Persistence.Repositories;

internal sealed class BillPaymentRepository : IBillPaymentRepository
{

    #region Properties 
    
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructor

    public BillPaymentRepository(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methods

    public async Task<BillPayment?> GetByIdAsync(Guid id) => await _dbContext.GetBydIdAsync<BillPayment>(id);

    public void Insert(BillPayment billPayment) => _dbContext.Insert(billPayment);

    public void Update(BillPayment billPayment) { }
    public void Delete(Guid id) { }
    #endregion
}
