using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UescColcicAPI.Core;
using UescColcicAPI.Services.BD.Interfaces;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var clientIp = context.Connection.RemoteIpAddress?.ToString();
        var hasJwtToken = context.Request.Headers.ContainsKey("Authorization");
        var requestDateTime = DateTime.Now;
        var requestMethod = context.Request.Method;
        var requestUrl = context.Request.Path;

        await _next(context);

        stopwatch.Stop();

        var processingTime = stopwatch.ElapsedMilliseconds / 1000.0;

        // Criar um objeto de log
        var requestLog = new RequestLog
        {
            ClientIp = clientIp,
            HasJwt = hasJwtToken,
            RequestDateTime = requestDateTime,
            RequestMethod = requestMethod,
            RequestUrl = requestUrl,
            ProcessingTime = processingTime
        };

        // Resolvendo o serviço dentro do escopo da solicitação
        using (var scope = context.RequestServices.CreateScope())
        {
            var requestLogService = scope.ServiceProvider.GetRequiredService<IBaseLog>();
            await requestLogService.LogRequestAsync(requestLog);
        }

        _logger.LogInformation(
            "Request Information: IP={IP}, HasJwt={HasJwt}, Time={Time}, Method={Method}, URL={URL}, ProcessingTime={ProcessingTime}s",
            clientIp, hasJwtToken, requestDateTime, requestMethod, requestUrl, processingTime);
    }
}
