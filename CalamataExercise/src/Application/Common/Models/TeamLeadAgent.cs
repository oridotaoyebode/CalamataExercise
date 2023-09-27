using CalamataExercise.Application.Common.Interfaces;

namespace CalamataExercise.Application.Common.Models;

public class TeamLeadAgent : IAgent
{
    public TeamLeadAgent()
    {
        Id = Guid.NewGuid();
    }

    public override string ToString()
    {
        return nameof(TeamLeadAgent);
    }

    public Guid Id { get; }
    
    public int Priority => 4;

    public int CurrentChats { get; set; }
    public double Multiplier => 0.5;
    
    public bool IsAvailable => CurrentChats < MaxConcurrentChats();

    
    public int MaxConcurrentChats()
    {
        return (int)(IAgent.MaxConcurrency * Multiplier);

    }
}