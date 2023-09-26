using CalamataExercise.Application.Common.Models;

namespace CalamataExercise.Application.Common.Interfaces;

public interface IQueueService<in T>
{
    Task SendMessage(T message, CancellationToken cancellationToken);
}