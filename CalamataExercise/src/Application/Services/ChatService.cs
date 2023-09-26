using CalamataExercise.Application.Common.Exceptions;
using CalamataExercise.Application.Common.Interfaces;
using CalamataExercise.Application.Common.Models;
using CalamataExercise.Domain.Events;
using Microsoft.Extensions.DependencyInjection.Common.Helper;

namespace Microsoft.Extensions.DependencyInjection.Services;

public class ChatService : IChatService
{
    private readonly IDateTime _dateTime;
    private readonly IEventService _eventService;

    public ChatService(IDateTime dateTime, IEventService eventService)
    {
        _dateTime = dateTime;
        _eventService = eventService;
    }
   

    public async Task InitiateChatRequest()
    {
        if (IsDuringOfficeHours())
        {
            var chatSession = new ChatSession(
                Guid.NewGuid(), 
                DateTimeOffset.Now, 
                TeamHelper.CreateDefaultTeamA());
            
            await AddSupportRequestToQueue(chatSession);
            
        }
        else
        {
            throw new ChatRefusedException("Chat refused as it is outside of office hours.");
        }
    }

    private bool IsDuringOfficeHours()
    {
       //check if current date time is during office hours of between 9am and 5pm. Monday to Friday.
       return _dateTime.Now.DayOfWeek != DayOfWeek.Saturday 
              && _dateTime.Now.DayOfWeek != DayOfWeek.Sunday 
              && _dateTime.Now.Hour is >= 9 and <= 17;
    }
    private async Task AddSupportRequestToQueue(ChatSession chatSession)
    {
        _eventService.Publish(new ChatSessionCreatedEvent(chatSession));
    }
    
}