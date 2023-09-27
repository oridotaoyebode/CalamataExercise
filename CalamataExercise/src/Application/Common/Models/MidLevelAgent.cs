using CalamataExercise.Application.Common.Interfaces;

namespace CalamataExercise.Application.Common.Models;

public class MidLevelAgent : IAgent
{
    public MidLevelAgent()
    {
        Id = Guid.NewGuid();
    }
    
    public override string ToString()
    {
        return nameof(MidLevelAgent);
    }

    public Guid Id { get; }
    
    public int Priority => 2;

    public int CurrentChats { get; set; }
    public double Multiplier => 0.6;
    
    public bool IsAvailable => CurrentChats < MaxConcurrentChats();

    public int MaxConcurrentChats()
    {
        return (int)(IAgent.MaxConcurrency * Multiplier);
    }
}