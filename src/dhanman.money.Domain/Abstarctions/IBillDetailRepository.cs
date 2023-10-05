using dhanman.money.Domain.Entities.BillDetails;

namespace dhanman.money.Domain.Abstarctions;

public interface IBillDetailRepository
{
    Task<BillDetail?> GetByIdAsync(Guid id);

    void Insert(BillDetail billDetail);
}
