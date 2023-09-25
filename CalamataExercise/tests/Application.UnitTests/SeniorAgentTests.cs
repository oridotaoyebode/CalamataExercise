using CalamataExercise.Application.Common.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CalamataExercise.Application.UnitTests;

public class SeniorAgentTests
{
    [Test]
    public void SeniorAgentConcurrentChatsReturnsCorrectValue()
    {
        var seniorAgent = new SeniorAgent();

        var actual = seniorAgent.ConcurrentChats();

        actual.Should().Be(8);
    }
}