using CalamataExercise.Application.Common.Interfaces;

namespace CalamataExercise.Application.Common.Models;

public class SeniorAgent : IAgent
{
    public SeniorAgent()
    {
        Id = Guid.NewGuid();
    }
    
    public override string ToString()
    {
        return nameof(SeniorAgent);
    }

    public Guid Id { get; }
    
    public int Priority => 3;

    public int CurrentChats { get; set; }
    public double Multiplier => 0.8;
    
    public bool IsAvailable => CurrentChats < MaxConcurrentChats();

    public int MaxConcurrentChats()
    {
        return (int)(IAgent.MaxConcurrency * Multiplier);

    }
}