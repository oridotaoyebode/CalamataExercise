namespace CalamataExercise.Application.Common.Exceptions;

public class ChatRefusedException : Exception
{
    public ChatRefusedException(string message) : base(message)
    {
    }
}