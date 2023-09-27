using CalamataExercise.Application.Common.Interfaces;

namespace CalamataExercise.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTimeOffset Now => new(2023, 09,26, 9,0,0, TimeSpan.Zero);
}