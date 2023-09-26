using CalamataExercise.Application.Common.Interfaces;
using CalamataExercise.Application.Common.Models;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection.Chat.Commands.Create;

public record CreateChatCommand() : IRequest<ValueTask>;

public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, ValueTask>
{
    private readonly IChatService _chatService;

    public CreateChatCommandHandler(IChatService chatService)
    {
        _chatService = chatService;
    }
    public async Task<ValueTask> Handle(CreateChatCommand request, CancellationToken cancellationToken)
    {
        await _chatService.InitiateChatRequest();

        return ValueTask.CompletedTask;
    }
}