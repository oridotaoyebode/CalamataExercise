using CalamataExercise.Application.Common.Models;
using CalamataExercise.Domain.Common;

namespace CalamataExercise.Domain.Events;

public class ChatSessionCreatedEvent : BaseEvent
{
    public ChatSessionCreatedEvent(ChatSession chatSession)
    {
        ChatSession = chatSession;
    }
    public ChatSession ChatSession { get; }
}