using CalamataExercise.Application.Common.Interfaces;

namespace CalamataExercise.Application.Common.Models;

public class JuniorAgent : IAgent
{
    public JuniorAgent()
    {
        Id = Guid.NewGuid();
    }
    
    public override string ToString()
    {
        return nameof(JuniorAgent);
    }
    public Guid Id { get; }
    public int Priority => 1;

    public int CurrentChats { get; set; }
    public double Multiplier => 0.4;
    
    public bool IsAvailable => CurrentChats < MaxConcurrentChats();

    public int MaxConcurrentChats()
    {
        return (int)(IAgent.MaxConcurrency * Multiplier);
    }
}