using CalamataExercise.Application.Common.Exceptions;
using CalamataExercise.Application.Common.Interfaces;
using CalamataExercise.Application.Common.Models;
using CalamataExercise.Domain.Common;
using CalamataExercise.Domain.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection.Common.Helper;

namespace Microsoft.Extensions.DependencyInjection.Chat.Commands.EventHandlers;

public class ChatSessionCreatedEventHandler : INotificationHandler<EventNotification<ChatSessionCreatedEvent>>
{
    private readonly Queue<ChatSession> _queue;

    public ChatSessionCreatedEventHandler()
    {
        _queue = new Queue<ChatSession>();
    }
    public async Task Handle(EventNotification<ChatSessionCreatedEvent> notification, CancellationToken cancellationToken)
    {
        if (_queue.Count <= notification.Event.ChatSession.Team.QueueSize())
        {
            _queue.Enqueue(notification.Event.ChatSession);
        }
        else
        {
            if (_queue.Count <= TeamHelper.CreateDefaultOverflowTeam().QueueSize())
            {
                _queue.Enqueue(notification.Event.ChatSession);
            }
            else
            {
                throw new ChatRefusedException("Chat refused as all teams are busy.");
            }
        }
    }
}