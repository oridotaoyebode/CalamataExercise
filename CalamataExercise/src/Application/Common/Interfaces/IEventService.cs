using CalamataExercise.Domain.Common;

namespace CalamataExercise.Application.Common.Interfaces;

public interface IEventService
{
    Task Publish(BaseEvent baseEvent);
}