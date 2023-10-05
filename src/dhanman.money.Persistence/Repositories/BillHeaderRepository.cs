using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Domain.Abstarctions;
using dhanman.money.Domain.Entities.BillHeaders;

namespace dhanman.money.Persistence.Repositories;

internal sealed class BillHeaderRepository : IBillHeaderRepositroy
{
    private readonly IApplicationDbContext _dbContext;

    public BillHeaderRepository(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<BillHeader?> GetByIdAsync(Guid id) => await _dbContext.GetBydIdAsync<BillHeader>(id);

    public void Insert(BillHeader billHeader) => _dbContext.Insert(billHeader);
}
