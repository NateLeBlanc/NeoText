using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using NeoText.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace NeoText.Server.Controllers;

[ApiController]
[ApiVersion("v1")]
[Route("api/v{apiVersion:apiVersion}/neotext/message")]
public class MessageController : ControllerBase
{
    [HttpPost("sendMessage")]
    [SwaggerOperation("Sends a message to message queue.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Message sent to queue.")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Unable to find queue.", typeof(ProblemDetails))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal error.", typeof(ProblemDetails))]
    public async Task<IActionResult> SendMessage([FromBody] ChatMessage chatMessage)
    {
        // TODO: Set up RabbitMQ broker
        // TODO: Create RMQ queue on message send (or on service start)
        // TODO: Send message object to be verified as valid and added to queue
        // TODO: Use a fan out exchange to send messages to multiple consumers at once

        return Ok();
    }

    [HttpGet("getMessage")]
    [SwaggerOperation("Gets messages from queue.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Message received.")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "No messages in queue.")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Unable to find queue.", typeof(ProblemDetails))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal error.", typeof(ProblemDetails))]
    public async Task<IActionResult> GetUser([FromBody] User user)
    {
        // TODO: Create consumer for message queue

        return Ok();
    }
}
