using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Domain.Abstarctions;
using dhanman.money.Domain.Entities.BillStatuses;

namespace dhanman.money.Persistence.Repositories;

internal sealed class BillStatusRepository : IBillStatusRepository
{
    private readonly IApplicationDbContext _dbContext;

    public BillStatusRepository(IApplicationDbContext dbContext) => _dbContext = dbContext;
    
    public async Task<BillStatus?> GetByIdAsync(Guid id) => await _dbContext.GetBydIdAsync<BillStatus>(id);

    public void Insert(BillStatus billStatus ) => _dbContext.Insert(billStatus);

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(BillStatus billStatus)
    {
        throw new NotImplementedException();
    }
}
