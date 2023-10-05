using dhanman.money.Domain.Entities.BillHeaders;

namespace dhanman.money.Domain.Abstarctions;

public interface IBillHeaderRepositroy
{
    Task<BillHeader?> GetByIdAsync(Guid id);

    void Insert(BillHeader billHeader);
}
