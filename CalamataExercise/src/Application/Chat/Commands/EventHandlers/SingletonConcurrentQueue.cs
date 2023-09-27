using System.Collections.Concurrent;

namespace Microsoft.Extensions.DependencyInjection.Chat.Commands.EventHandlers;


//Thread-safe Singleton ConcurrentQueue - This would normally be some some of a message broker like Kafka or Azure Service bus or RabbitMQ
public class SingletonConcurrentQueue<T> : ConcurrentQueue<T>
{
    //Static instance for entire app lifecycle. Will probably cause issues for tests but this is just a demo
    private static readonly SingletonConcurrentQueue<T> MainQueueInstance = new();
    private static readonly SingletonConcurrentQueue<T> OverflowQueueInstance = new();

    static SingletonConcurrentQueue(){}
    private SingletonConcurrentQueue(){}

    public static SingletonConcurrentQueue<T> MainQueue
    {
        get { return MainQueueInstance; }
    }
    
    public static SingletonConcurrentQueue<T> OverFlowQueue
    {
        get { return OverflowQueueInstance; }
    }
}