using CalamataExercise.Application.Common.Interfaces;

namespace CalamataExercise.Application.Common.Models;

public class SeniorAgent : IAgent
{
    public double Multiplier => 0.8;
    public double ConcurrentChats()
    {
        return IAgent.MaxConcurrency * Multiplier;
    }
}