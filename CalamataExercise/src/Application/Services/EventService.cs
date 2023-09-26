using CalamataExercise.Application.Common.Interfaces;
using CalamataExercise.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection.Services;

public class EventService : IEventService
{
    private readonly ILogger<EventService> _logger;
    private readonly IPublisher _publisher;

    public EventService(ILogger<EventService> logger, IPublisher publisher)
    {
        _logger = logger;
        _publisher = publisher;
    }
    public async Task Publish(BaseEvent baseEvent)
    {
        try
        {
            _logger.LogInformation("Publishing event. Event: {Event}", baseEvent.GetType().Name);
            await _publisher.Publish(GetNotification(baseEvent));
        }
        catch (Exception e)
        {
           _logger.LogError("Error publishing event. Event: {Event}. Error: {Error}", baseEvent.GetType().Name, e.Message);
        }
    }
    
    private static INotification GetNotification(BaseEvent baseEvent)
    {
        var notification = (INotification) Activator.CreateInstance(
            typeof(EventNotification<>).MakeGenericType(baseEvent.GetType()), baseEvent);
        return notification;
    }
}