namespace CalamataExercise.Application.Common.Interfaces;

public interface ITeam
{
    public static double TeamMultiplier => 1.5;
    
    List<IAgent> Agents { get; }
    
    int QueueSize();

}