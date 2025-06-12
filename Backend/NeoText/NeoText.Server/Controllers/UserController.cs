using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeoText.DatabaseHandlers;
using NeoText.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace NeoText.Server.Controllers;

[ApiController]
[ApiVersion("v1")]
[Route("api/v{apiVersion:apiVersion}/neotext/user")]
public class UserController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("createUser")]
    [SwaggerOperation("Creates a new user.")]
    [SwaggerResponse(StatusCodes.Status200OK, "New User created.")]
    [SwaggerResponse(StatusCodes.Status409Conflict, "User already exists.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal error.", typeof(ProblemDetails))]
    public async Task<IActionResult> CreateUser([FromBody] User newUser, CancellationToken cancellationToken)
    {
        // TODO: Create Database on Postgres
        // TODO: Check for existing/matching Username in database
        var request = new CreateUserRequest()
        {
            UserName = newUser.UserName,
            Password = newUser.Password
        };
        CreateUserResponse result = await _mediator.Send(request, cancellationToken);

        return Ok(result);
    }

    [HttpGet("getUser")]
    [SwaggerOperation("Gets an existing user.")]
    [SwaggerResponse(StatusCodes.Status200OK, "New User created.")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Unable to find user.", typeof(ProblemDetails))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Invalid password for user.", typeof(ProblemDetails))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal error.", typeof(ProblemDetails))]
    public async Task<IActionResult> GetUser([FromBody] User user)
    {
        // TODO: Get user from database
        // TODO: Return valid not found if username doesn't exist
        // TODO: Return valid wrong password if password doesn't match

        return Ok();
    }
}
