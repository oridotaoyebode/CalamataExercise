using CalamataExercise.Application.Common.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CalamataExercise.Application.UnitTests;

public class TeamLeadAgentTests
{
    [Test]
    public void TeamLeadAgentConcurrentChatsReturnsCorrectValue()
    {
        var teamLeadAgent = new TeamLeadAgent();

        var actual = teamLeadAgent.MaxConcurrentChats();

        actual.Should().Be(5);
    }
}