// Services/RequestLoggingService.cs
namespace StudentPortal.Services;

/// <summary>
/// Concrete implementation of IRequestLoggingService.
/// Registered as Singleton: one instance for the app's lifetime.
/// A lock ensures thread-safe access to the shared list.
/// </summary>
public class RequestLoggingService : IRequestLoggingService
{
    private readonly List<RequestLogEntry> _logs = new();
    private readonly object _lock = new();


    public void Log(string url, long executionTimeMs, string operation = "GET")
    {
        lock (_lock)
        {
            _logs.Add(new RequestLogEntry
            {
                Url = url,
                ExecutionTimeMs = executionTimeMs,
                Timestamp = DateTime.UtcNow,
                Operation = operation
            });
        }
    }

    public IReadOnlyList<RequestLogEntry> GetLogs()
    {
        lock (_lock)   // thread-safe read
        {
            return _logs.AsReadOnly();
        }
    }
}
