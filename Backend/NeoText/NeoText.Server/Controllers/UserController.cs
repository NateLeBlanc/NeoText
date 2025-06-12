using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using NeoText.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace NeoText.Server.Controllers;

[ApiController]
[ApiVersion("v1")]
[Route("api/v{apiVersion:apiVersion}/neotext/user")]
public class UserController : ControllerBase
{
    [HttpPost("createUser")]
    [SwaggerOperation("Creates a new user.")]
    [SwaggerResponse(StatusCodes.Status200OK, "New User created.")]
    [SwaggerResponse(StatusCodes.Status409Conflict, "User already exists.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal error.", typeof(ProblemDetails))]
    public async Task<IActionResult> CreateUser([FromBody] User newUser)
    {
        // TODO: Set up DBContext
        // TODO: Create Database on Postgres
        // TODO: Send newUser to database
        // TODO: Check for existing/matching Username in database

        return Ok();
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
