using MediatR;

namespace NeoText.DatabaseHandlers;
public class CreateUserRequest : IRequest<CreateUserResponse>
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
