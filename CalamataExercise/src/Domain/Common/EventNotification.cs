using MediatR;

namespace CalamataExercise.Domain.Common;

public class EventNotification<T> : INotification
    where T : BaseEvent
{
    public EventNotification(T @event)
    {
        this.Event = @event;
    }

    public T Event { get; }
}