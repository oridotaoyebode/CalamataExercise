using CalamataExercise.Application.Common.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CalamataExercise.Application.UnitTests;


public class JuniorAgentTests
{
    [Test]
    public void JuniorAgentConcurrentChatsReturnsCorrectValue()
    {
        var juniorAgent = new JuniorAgent();

        var actual = juniorAgent.MaxConcurrentChats();

        actual.Should().Be(4);
    }
}