using dhanman.money.Domain.Exceptions.Base;

namespace dhanman.money.Domain.Exceptions;

public sealed class BillPaymentNotFoundException : NotFoundException
{
    public BillPaymentNotFoundException(Guid billPaymentId)
        : base($"The bill Payment Id with the identifier {billPaymentId} was not found.")
    {

    }
}
