using CalamataExercise.Application.Common.Interfaces;

namespace CalamataExercise.Application.Common.Models;

public class JuniorAgent : IAgent
{
    public double Multiplier => 0.4;
    public double ConcurrentChats()
    {
        return IAgent.MaxConcurrency * Multiplier;
    }
}