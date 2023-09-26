using CalamataExercise.Application.Common.Models;

namespace CalamataExercise.Application.Common.Interfaces;

public interface IChatService
{
    Task InitiateChatRequest();
}