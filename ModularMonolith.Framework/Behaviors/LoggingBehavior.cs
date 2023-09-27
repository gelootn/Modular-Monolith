using System.Diagnostics;

using MediatR;
using ModularMonolith.Framework.Responses;
using Serilog;

namespace ModularMonolith.Framework.Behaviors;

public class LoggingBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse> 
    where TRequest : notnull
{
    private readonly ILogger _logger;

    public LoggingBehavior(ILogger logger)
    {
        _logger = logger;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.Debug("Handling {RequestType} with request {@Request}", typeof(TRequest).Name, request);
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = await next();
        stopwatch.Stop();
        _logger.Debug("Handled {RequestType} in {ElapsedMilliseconds}ms", typeof(TRequest).Name, stopwatch.ElapsedMilliseconds);
        
        return result;
    }
}