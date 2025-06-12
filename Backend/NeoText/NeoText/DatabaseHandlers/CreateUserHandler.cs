using MediatR;
using Microsoft.AspNetCore.Identity;
using NeoText.Database;
using NeoText.Domain.Models;

namespace NeoText.DatabaseHandlers;
public class CreateUserHandler(IUserRepository userRepository) : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrEmpty(request.UserName))
        {
            throw new ArgumentException("Username is required.");
        }

        User newUser = new User
        {
            UserName = request.UserName,
            Password = HashPassword(request.Password)
        };

        await userRepository.AddUserAsync(newUser, cancellationToken);

        return new CreateUserResponse()
        {
            UserId = newUser.UserId,
            UserName = request.UserName,
        };
    }

    private static string HashPassword(string password)
    {
        var hasher = new PasswordHasher<object>();
        return hasher.HashPassword(null, password);
    }
}
