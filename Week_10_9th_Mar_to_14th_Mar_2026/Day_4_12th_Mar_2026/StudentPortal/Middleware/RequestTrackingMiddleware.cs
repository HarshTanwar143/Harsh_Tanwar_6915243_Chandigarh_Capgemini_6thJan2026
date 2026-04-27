// Middleware/RequestTrackingMiddleware.cs
using System.Diagnostics;
using StudentPortal.Services;

namespace StudentPortal.Middleware;

/// <summary>
/// Custom middleware that measures each request's execution time
/// and stores the URL + time in IRequestLoggingService via DI.
/// </summary>
public class RequestTrackingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IRequestLoggingService _loggingService;

    // Constructor: both _next and IRequestLoggingService injected by DI
    public RequestTrackingMiddleware(
        RequestDelegate next,
        IRequestLoggingService loggingService)
    {
        _next = next;
        _loggingService = loggingService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();   // ← start timer

        await _next(context);                   // ← call next middleware

        stopwatch.Stop();                       // ← stop timer

        var url = context.Request.Path.ToString();
        _loggingService.Log(url, stopwatch.ElapsedMilliseconds);
    }
}
