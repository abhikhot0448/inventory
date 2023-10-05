using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Domain.Abstarctions;
using dhanman.money.Domain.Entities.BillDetails;

namespace dhanman.money.Persistence.Repositories;

internal sealed class BillDetailRepository : IBillDetailRepository
{
    private readonly IApplicationDbContext _dbContext;

    public BillDetailRepository(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<BillDetail?> GetByIdAsync(Guid id) => await _dbContext.GetBydIdAsync<BillDetail>(id);

    public void Insert(BillDetail billDetail) => _dbContext.Insert(billDetail);
}
