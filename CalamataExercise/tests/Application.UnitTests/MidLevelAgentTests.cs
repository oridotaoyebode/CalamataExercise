using CalamataExercise.Application.Common.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CalamataExercise.Application.UnitTests;

public class MidLevelAgentTests
{
    [Test]
    public void MidLevelConcurrentChatsReturnsCorrectValue()
    {
        var midLevelAgent = new MidLevelAgent();

        var actual = midLevelAgent.MaxConcurrentChats();

        actual.Should().Be(6);
    }
}