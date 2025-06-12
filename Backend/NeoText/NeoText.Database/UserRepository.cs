using NeoText.Domain.Models;

namespace NeoText.Database;
public class UserRepository(UserDbContext userDbContext) : IUserRepository
{
    private readonly UserDbContext _userDbContext = userDbContext;

    public async Task AddUserAsync(User newUser, CancellationToken cancellationToken)
    {
        _userDbContext.User.Add(newUser);
        await _userDbContext.SaveChangesAsync(cancellationToken);
    }
}
