using CalamataExercise.Application.Common.Interfaces;

namespace CalamataExercise.Application.Common.Models;

public class TeamLeadAgent : IAgent
{
    public double Multiplier => 0.5;
    public double ConcurrentChats()
    {
        return IAgent.MaxConcurrency * Multiplier;
    }
}