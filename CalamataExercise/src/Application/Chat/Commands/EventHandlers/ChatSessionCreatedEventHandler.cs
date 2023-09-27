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
    private readonly SingletonConcurrentQueue<ChatSession> _mainQueue;
    private readonly SingletonConcurrentQueue<ChatSession> _overFlowQueue;
    public ChatSessionCreatedEventHandler()
    {
        _mainQueue = SingletonConcurrentQueue<ChatSession>.MainQueue;
        _overFlowQueue = SingletonConcurrentQueue<ChatSession>.OverFlowQueue;
    }
    public async Task Handle(EventNotification<ChatSessionCreatedEvent> notification, CancellationToken cancellationToken)
    {
        if (_mainQueue.Count < TeamHelper.CreateDefaultTeamA().QueueSize())
        {
            //Agents are available to take the chat
            _mainQueue.Enqueue(notification.Event.ChatSession);
        }
        else
        {
            //Agents are busy, check if there is space in the overflow team
            if (_overFlowQueue.Count < TeamHelper.CreateDefaultOverflowTeam().QueueSize())
            {
                _overFlowQueue.Enqueue(notification.Event.ChatSession);
            }
            else
            {
                throw new ChatRefusedException("Chat refused as all teams are busy.");
            }
        }
    }
}