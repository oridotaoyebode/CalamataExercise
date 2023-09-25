using CalamataExercise.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace CalamataExercise.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly ICurrentUserService _currentUserService;

    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;


        _logger.LogInformation("CalamataExercise Request: {Name}  {@Request}",
            requestName, request);
    }
}