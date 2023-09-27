using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Chat.Commands.Create;
using NSwag.Annotations;

namespace CalamataExercise.WebUI.Controllers;

public class ChatController : ApiControllerBase
{
    [HttpPost]
    [Route("chat")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [OpenApiOperation("Initiate a support request", "Initiate a support request")]
    public async Task<IActionResult> AddSupportRequestToQueue()
    {
        return Ok(await Mediator.Send(new CreateChatCommand(1)));
    }
    
    [HttpPost]
    [Route("chat/{count:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [OpenApiOperation("Initiate a support request", "Initiate a support request")]
    public async Task<IActionResult> AddSupportRequestToQueue(int count)
    {
        return Ok(await Mediator.Send(new CreateChatCommand(count)));
    }
}