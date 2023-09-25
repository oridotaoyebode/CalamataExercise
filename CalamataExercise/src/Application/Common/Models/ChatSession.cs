using CalamataExercise.Application.Common.Interfaces;

namespace CalamataExercise.Application.Common.Models;

public class ChatSession
{
    public Guid SessionId { get; }
    public DateTimeOffset CreatedAt { get; }
    public ITeam Team { get; }

    public ChatSession(Guid sessionId, DateTimeOffset createdAt, ITeam team)
    {
        SessionId = sessionId;
        CreatedAt = createdAt;
        Team = team;
    }
}