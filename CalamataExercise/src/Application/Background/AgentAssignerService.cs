using CalamataExercise.Application.Common.Interfaces;
using CalamataExercise.Application.Common.Models;
using Microsoft.Extensions.DependencyInjection.Chat.Commands.EventHandlers;
using Microsoft.Extensions.DependencyInjection.Common.Helper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection.Background;

public class AgentAssignerService : BackgroundService
{
    private readonly ILogger<AgentAssignerService> _logger;
    private SingletonConcurrentQueue<ChatSession> _mainQueue;
    private SingletonConcurrentQueue<ChatSession> _overflowQueue;
    public AgentAssignerService(ILogger<AgentAssignerService> logger)
    {
        _logger = logger;
        _mainQueue = SingletonConcurrentQueue<ChatSession>.MainQueue;
        _overflowQueue = SingletonConcurrentQueue<ChatSession>.OverFlowQueue;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("AgentAssignerService is starting.");
        while (true)
        {
            await Task.Delay(1000, stoppingToken);
            if (_mainQueue.Any() && _mainQueue.TryDequeue(out var chatSession))
            {
                _logger.LogInformation($"Chat has been dequeued ready to be assigned to an agent");

                //Logic for assigning a chat to an agent. 
                //This is where the chat session would be assigned to an agent and the agent would be notified.
                var agents = TeamHelper.CreateDefaultTeamA().Agents;
                AssignAgent(agents, chatSession);
                
            }
            else if (_overflowQueue.Any() && _overflowQueue.TryDequeue(out var chatSessionOverflow))
            {
                _logger.LogInformation($"Chat has been dequeued ready to be assigned to an agent");

                //Logic for assigning a chat to an agent. 
                //This is where the chat session would be assigned to an agent and the agent would be notified.
                var agents = TeamHelper.CreateDefaultOverflowTeam().Agents;
                AssignAgent(agents, chatSessionOverflow);
            }
            
        }
        
    }

   

    private void AssignAgent(List<IAgent> agents, ChatSession chatSession)
    {
        var availableAgents = agents.Where(agent => agent.IsAvailable).ToList();
        if (availableAgents.Any())
        {
            var nextAgent = availableAgents
                .OrderBy(agent => agent.Priority)
                .First();

            chatSession.SetAgent(nextAgent);
            _logger.LogInformation("Chat session has been assigned to agent {S} : {NextAgentId}", nextAgent.ToString(), nextAgent.Id);
        }
        else
        {
            _logger.LogInformation("No agents available to take chat session {ChatSessionSessionId}", chatSession.SessionId);
        }
    }
}