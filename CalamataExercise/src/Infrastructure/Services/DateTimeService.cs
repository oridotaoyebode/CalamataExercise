using CalamataExercise.Application.Common.Interfaces;

namespace CalamataExercise.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}