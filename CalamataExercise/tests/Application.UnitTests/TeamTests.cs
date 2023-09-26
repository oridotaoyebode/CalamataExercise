using CalamataExercise.Application.Common.Interfaces;
using CalamataExercise.Application.Common.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CalamataExercise.Application.UnitTests;

public class TeamTests
{
    [Test]
    public void Team1TeamLeadAnd2MidLevel1JuniorAgentShouldReturnCorrectResult()
    {
        
        var actual = new List<IAgent> {new TeamLeadAgent(), new MidLevelAgent(), new MidLevelAgent(), new JuniorAgent()};
        
        var team = new Team(actual);
        
        team.QueueSize().Should().Be(31);
    }
    
    [Test]
    public void Team1SeniorLevelAnd1MidLevelAnd2JuniorShouldReturnCorrectResult()
    {
        var actual = new List<IAgent> {new SeniorAgent(), new MidLevelAgent(), new JuniorAgent(), new JuniorAgent()};
        
        var team = new Team(actual);
        
        team.QueueSize().Should().Be(33);
    }
    
    [Test]
    public void Team2MidLevelShouldReturnCorrectResult()
    {
        var actual = new List<IAgent> {new MidLevelAgent(), new MidLevelAgent()};
        
        var team = new Team(actual);
       
        team.QueueSize().Should().Be(18);
    }
    
    [Test]
    public void TeamOverFlowShouldReturnCorrectResult()
    {
        
        var actual = new List<IAgent> {
            new JuniorAgent(), 
            new JuniorAgent(),
            new JuniorAgent(),
            new JuniorAgent(),
            new JuniorAgent(),
            new JuniorAgent()
            
        };
        
        var team = new Team(actual);
        
        team.QueueSize().Should().Be(36);
    }
}