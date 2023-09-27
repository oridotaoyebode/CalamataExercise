using CalamataExercise.Application.Common.Interfaces;
using CalamataExercise.Application.Common.Models;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection.Chat.Commands.Create;

public record CreateChatCommand(int Count) : IRequest<ValueTask>;

public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, ValueTask>
{
    private readonly IChatService _chatService;

    public CreateChatCommandHandler(IChatService chatService)
    {
        _chatService = chatService;
    }
    public async Task<ValueTask> Handle(CreateChatCommand request, CancellationToken cancellationToken)
    {
        for (int i = 0; i < request.Count; i++)
        {
            await _chatService.InitiateChatRequest();

        }

        return ValueTask.CompletedTask;
    }
}