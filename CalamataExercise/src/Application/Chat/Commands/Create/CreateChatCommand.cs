using CalamataExercise.Application.Common.Models;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection.Chat.Commands.Create;

public record CreateChatCommand() : IRequest<ChatResponse>;

public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, ChatResponse>
{
    
    public Task<ChatResponse> Handle(CreateChatCommand request, CancellationToken cancellationToken)
    {
        return null;
    }
}