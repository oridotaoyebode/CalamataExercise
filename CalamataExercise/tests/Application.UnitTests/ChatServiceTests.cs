using CalamataExercise.Application.Common.Exceptions;
using CalamataExercise.Application.Common.Interfaces;
using CalamataExercise.Domain.Common;
using Microsoft.Extensions.DependencyInjection.Services;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace CalamataExercise.Application.UnitTests;

public class ChatServiceTests
{
    [Test]
    public async Task InitiateServiceRequestShouldReturnCorrectResult()
    {
        var mockDateTime = new Mock<IDateTime>();
        var mockEventService = new Mock<IEventService>();
        mockDateTime.Setup(x=> x.Now).Returns(new DateTime(2023, 09, 25, 10, 10, 10));
        mockEventService.Setup(x => x.Publish(It.IsAny<BaseEvent>())).Returns(Task.CompletedTask);
        var chatService = new ChatService(mockDateTime.Object, mockEventService.Object);

        await chatService.InitiateChatRequest();
    }
    
    [Test]
    public async Task InitiateServiceRequestShouldThrowExceptionOutsideOfficeHours()
    {
        var mockDateTime = new Mock<IDateTime>();
        var mockEventService = new Mock<IEventService>();
        mockDateTime.Setup(x=> x.Now).Returns(new DateTime(2023, 09, 25, 18, 10, 10));
        mockEventService.Setup(x => x.Publish(It.IsAny<BaseEvent>())).Returns(Task.CompletedTask);
        var chatService = new ChatService(mockDateTime.Object, mockEventService.Object);

        await Should.ThrowAsync<ChatRefusedException>(async () => await chatService.InitiateChatRequest());
    }
}