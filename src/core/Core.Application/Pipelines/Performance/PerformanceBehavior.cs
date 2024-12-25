using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Application.Pipelines.Performance;

//Bir Command veya Query çalıştığı andan itibaren 500ms dan fazla tepki vermezse sisteme log atsın

public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : IRequest<TResponse>,IPerformanceRequest
{
    private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;

    public PerformanceBehavior(ILogger<PerformanceBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        //Kronometreyi response dönmeden başlat
        var stopwatch = Stopwatch.StartNew();
        TResponse response = await next();
        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds>500)
        {
            _logger.LogWarning("{RequestName}:{elapsedMilliseconds}",typeof(TRequest).Name, stopwatch.ElapsedMilliseconds, stopwatch.ElapsedMilliseconds);
        }
        return response;
    }
}