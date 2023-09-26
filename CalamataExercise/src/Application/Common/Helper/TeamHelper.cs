using CalamataExercise.Application.Common.Interfaces;
using CalamataExercise.Application.Common.Models;

namespace Microsoft.Extensions.DependencyInjection.Common.Helper;

public static class TeamHelper
{
    public static Team CreateDefaultTeamA()
    {
        var agents = new List<IAgent>
        {
                new TeamLeadAgent(), new MidLevelAgent(), new MidLevelAgent(), new JuniorAgent()
            };
        return new Team(agents);
    }
    
    public static Team CreateDefaultTeamB()
    {
        var agents = new List<IAgent>
        {
            new SeniorAgent(), new MidLevelAgent(), new JuniorAgent(), new JuniorAgent()
        };
        return new Team(agents);
    }
    
    public static Team CreateDefaultTeamC()
    {
        var agents = new List<IAgent>
        {
            new MidLevelAgent(), new MidLevelAgent()
        };
        return new Team(agents);
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