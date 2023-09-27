namespace CalamataExercise.Application.Common.Interfaces;

public interface IAgent
{
    public static int MaxConcurrency => 10;
    
    Guid Id { get; }
    int Priority { get; }
    double Multiplier { get; }
    int CurrentChats { get; set; }
    bool IsAvailable { get; }
    int MaxConcurrentChats();
    
}