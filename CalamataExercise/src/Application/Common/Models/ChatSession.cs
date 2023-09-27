using CalamataExercise.Application.Common.Interfaces;

namespace CalamataExercise.Application.Common.Models;

public class ChatSession
{
    public Guid SessionId { get; }
    public DateTimeOffset CreatedAt { get; }

    private IAgent Agent { get; set; }
    
    public ChatSession(Guid sessionId, DateTimeOffset createdAt)
    {
        SessionId = sessionId;
        CreatedAt = createdAt;
    }
    
    public bool SetAgent(IAgent agent)
    {
        if (agent.MaxConcurrentChats() <= agent.CurrentChats)
        {
            return false;
        }
        
        agent.CurrentChats++;

        this.Agent = agent;
        return true;

    }

    
}