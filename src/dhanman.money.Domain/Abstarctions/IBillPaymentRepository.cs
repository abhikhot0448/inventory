using dhanman.money.Domain.Entities.BillPayments;

namespace dhanman.money.Domain.Abstarctions;
public interface IBillPaymentRepository
{
    Task<BillPayment?> GetByIdAsync(Guid id);

    void Insert(BillPayment billPayment);

    void Update(BillPayment billPayment);

    void Delete(Guid billPaymentId);   
}
