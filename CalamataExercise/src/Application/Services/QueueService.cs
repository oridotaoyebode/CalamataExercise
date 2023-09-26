namespace CalamataExercise.Application.Common.Interfaces;

public class QueueService<T> : IQueueService<T>
{
    private readonly Queue<T> _queue;
    public QueueService()
    {
        _queue = new Queue<T>();
    }

    public Task SendMessage(T message, CancellationToken cancellationToken)
    {
        _queue.Enqueue(message);

        return Task.CompletedTask;
    }
}