namespace CalamataExercise.Application.Common.Interfaces;

public interface IAgent
{
    public static int MaxConcurrency => 10;
    
    double Multiplier { get; }
    
    double ConcurrentChats();
}