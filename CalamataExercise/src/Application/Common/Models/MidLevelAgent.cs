using CalamataExercise.Application.Common.Interfaces;

namespace CalamataExercise.Application.Common.Models;

public class MidLevelAgent : IAgent
{
    public double Multiplier => 0.6;
    public double ConcurrentChats()
    {
        return IAgent.MaxConcurrency * Multiplier;
    }
}