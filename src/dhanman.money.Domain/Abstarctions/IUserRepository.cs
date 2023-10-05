using dhanman.money.Domain.Entities.Users;

namespace dhanman.money.Domain.Abstarctions
{
    public interface IUserRepository
    {
        Task<bool> IsEmailUniqueAsync(string email);

        
    }
}
