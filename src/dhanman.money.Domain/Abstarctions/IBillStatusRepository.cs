using dhanman.money.Domain.Entities.BillStatuses;

namespace dhanman.money.Domain.Abstarctions;

public  interface IBillStatusRepository
{
    Task<BillStatus?> GetByIdAsync(Guid id);

    void Insert(BillStatus billStatus);

    void Update(BillStatus billStatus);

    Task<bool> Delete(Guid id);
}
