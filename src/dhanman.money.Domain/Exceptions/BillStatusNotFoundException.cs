using dhanman.money.Domain.Exceptions.Base;

namespace dhanman.money.Domain.Exceptions;

public sealed class BillStatusNotFoundException : NotFoundException
{
    public BillStatusNotFoundException(Guid billStatusId)
        :base($"The bill status with the identifier {billStatusId} was not found.")
    {
        
    }
}
