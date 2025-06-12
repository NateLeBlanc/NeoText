using NeoText.Domain.Models;

namespace NeoText.Database;
public interface IUserRepository
{
    Task AddUserAsync(User newUser, CancellationToken cancellationToken);
}
