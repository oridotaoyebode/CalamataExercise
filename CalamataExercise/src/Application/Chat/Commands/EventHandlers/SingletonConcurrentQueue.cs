using System.Collections.Concurrent;

namespace Microsoft.Extensions.DependencyInjection.Chat.Commands.EventHandlers;


//Thread-safe Singleton ConcurrentQueue
public class SingletonConcurrentQueue<T> : ConcurrentQueue<T>
{
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