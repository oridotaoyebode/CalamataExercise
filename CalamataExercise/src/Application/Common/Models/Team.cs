using CalamataExercise.Application.Common.Interfaces;

namespace CalamataExercise.Application.Common.Models;

public class Team : ITeam
{
    public Team(List<IAgent> agents)
    {
        Agents = agents;
    }
    public List<IAgent> Agents { get; }

    public int QueueSize()
    {
        if (Agents.Any())
        {
            //Cast to integer to round down
            return (int)(Agents.Sum(agent => agent.ConcurrentChats()) * ITeam.TeamMultiplier);
        }

        return 0;
    }
}