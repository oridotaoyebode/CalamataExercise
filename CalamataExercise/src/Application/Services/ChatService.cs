using CalamataExercise.Application.Common.Exceptions;
using CalamataExercise.Application.Common.Interfaces;
using CalamataExercise.Application.Common.Models;

namespace Microsoft.Extensions.DependencyInjection.Services;

public class ChatService : IChatService
{
    private readonly IDateTime _dateTime;
    private readonly ITeam _team;
    private readonly Queue<ChatSession> _queue;
    public ChatService(IDateTime dateTime, ITeam team)
    {
        _dateTime = dateTime;
        _team = team;
        _queue = new Queue<ChatSession>();
    }
    public async Task<bool> AddSupportRequestToQueue(ChatSession chatSession)
    {
        _queue.Enqueue(chatSession);
        return true;
    }

    public async Task<bool> RemoveSupportRequestFromQueue(ChatSession chatSession)
    {
        return _queue.Any() && _queue.TryDequeue(out chatSession);
    }

    public Task InitiateChatRequest()
    {
        if (IsDuringOfficeHours())
        {
            if (_queue.Count < _team.QueueSize())
            {
                //Add to queue

                var chatSession = new ChatSession(Guid.NewGuid(), DateTimeOffset.Now, _team);
                AddSupportRequestToQueue(chatSession);
            }
            else
            {
                //Use overflow 
                var agents = new List<IAgent>()
                {
                    new JuniorAgent(),
                    new JuniorAgent(),
                    new JuniorAgent(),
                    new JuniorAgent(),
                    new JuniorAgent(),
                    new JuniorAgent(),
                };
                var chatSession = new ChatSession(Guid.NewGuid(), DateTimeOffset.Now, new Team(agents));
                
                AddSupportRequestToQueue(chatSession);
            }
            
        }
        else
        {
            throw new ChatRefusedException("Chat refused as it is outside of office hours.");
        }

        return Task.CompletedTask;
    }

    public bool IsDuringOfficeHours()
    {
       //check if current date time is during office hours of between 9am and 5pm. Monday to Friday.
       return _dateTime.Now.DayOfWeek != DayOfWeek.Saturday 
                && _dateTime.Now.DayOfWeek != DayOfWeek.Sunday 
                && _dateTime.Now.Hour >= 9 && _dateTime.Now.Hour <= 17;
       
    }
}