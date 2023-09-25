using CalamataExercise.Application.Common.Models;

namespace CalamataExercise.Application.Common.Interfaces;

public interface IChatService
{
    Task<bool> AddSupportRequestToQueue(ChatSession chatSession);
    
    Task<bool> RemoveSupportRequestFromQueue(ChatSession chatSession);

    Task InitiateChatRequest();
}