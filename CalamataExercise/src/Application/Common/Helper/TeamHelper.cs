using CalamataExercise.Application.Common.Interfaces;
using CalamataExercise.Application.Common.Models;

namespace Microsoft.Extensions.DependencyInjection.Common.Helper;

public static class TeamHelper
{
    private static List<IAgent> _agents;

    static TeamHelper()
    {
        _agents = new List<IAgent>
        {
            new TeamLeadAgent(), new MidLevelAgent(), new MidLevelAgent(), new JuniorAgent()
        };
    }
    public static Team CreateDefaultTeamA()
    {
        return new Team(_agents);
    }
    
    
    public static Team CreateDefaultOverflowTeam()
    {
        var agents = new List<IAgent>
        {
            new JuniorAgent(),
            new JuniorAgent(),
            new JuniorAgent(),
            new JuniorAgent(),
            new JuniorAgent(),
            new JuniorAgent()
        };
        return new Team(agents);
    }
}