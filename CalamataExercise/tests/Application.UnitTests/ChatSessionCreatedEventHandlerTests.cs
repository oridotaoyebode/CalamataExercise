using CalamataExercise.Application.Common.Exceptions;
using CalamataExercise.Application.Common.Interfaces;
using CalamataExercise.Application.Common.Models;
using CalamataExercise.Domain.Common;
using CalamataExercise.Domain.Events;
using Microsoft.Extensions.DependencyInjection.Chat.Commands.EventHandlers;
using Microsoft.Extensions.DependencyInjection.Common.Helper;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace CalamataExercise.Application.UnitTests;

public class ChatSessionCreatedEventHandlerTests
{
    [Test]
    public async Task HandleShouldReturnCorrectResult()
    {
       var chatSessionCreatedEventHandler = new ChatSessionCreatedEventHandler();
       var mockDateTime = new Mock<IDateTime>();
       mockDateTime.Setup(x => x.Now).Returns(DateTimeOffset.Now);
       var chatSession = new ChatSession(Guid.NewGuid(), mockDateTime.Object.Now);
       var eventNotification = new EventNotification<ChatSessionCreatedEvent>(new ChatSessionCreatedEvent(chatSession));
       await chatSessionCreatedEventHandler.Handle(eventNotification, CancellationToken.None);
       SingletonConcurrentQueue<ChatSession>.MainQueue.Count.ShouldBe(1);
       SingletonConcurrentQueue<ChatSession>.OverFlowQueue.Count.ShouldBe(0);

    }
    
    [Test]
    public async Task HandleShouldGotoOverFlowQueueWhenQueueIsFull()
    {
        var chatSessionCreatedEventHandler = new ChatSessionCreatedEventHandler();
        var mockDateTime = new Mock<IDateTime>();
        mockDateTime.Setup(x => x.Now).Returns(DateTimeOffset.Now);
      
        for (int i = 1; i <= 50; i++)
        {
            var chatSession = new ChatSession(Guid.NewGuid(), mockDateTime.Object.Now);
            var eventNotification = new EventNotification<ChatSessionCreatedEvent>(new ChatSessionCreatedEvent(chatSession));
            await chatSessionCreatedEventHandler.Handle(eventNotification, CancellationToken.None);
        }

        var queueSize = TeamHelper.CreateDefaultTeamA().QueueSize();
        var overFlowQueueSize = TeamHelper.CreateDefaultOverflowTeam().QueueSize();
        SingletonConcurrentQueue<ChatSession>.MainQueue.Count.ShouldBe(queueSize);
        SingletonConcurrentQueue<ChatSession>.OverFlowQueue.Count.ShouldBe(50-queueSize);
        SingletonConcurrentQueue<ChatSession>.OverFlowQueue.Count.ShouldBeLessThan(overFlowQueueSize);

    }
    
    [Test]
    public async Task HandleShouldGotoOverFlowQueueWhenQueueIsFullAndThrowException_When_OverFlow_Is_Full()
    {
        var chatSessionCreatedEventHandler = new ChatSessionCreatedEventHandler();
        var mockDateTime = new Mock<IDateTime>();
        mockDateTime.Setup(x => x.Now).Returns(DateTimeOffset.Now);
        for (int i = 0; i < 100; i++)
        {
            var chatSession = new ChatSession(Guid.NewGuid(), mockDateTime.Object.Now);
            var eventNotification = new EventNotification<ChatSessionCreatedEvent>(new ChatSessionCreatedEvent(chatSession));
            await chatSessionCreatedEventHandler.Handle(eventNotification, CancellationToken.None);
        }
        
    }
}