// Services/IRequestLoggingService.cs
namespace StudentPortal.Services;

/// <summary>
/// Interface for logging service — registered in DI container.
/// Stores URL and execution time for each HTTP request.
/// </summary>
public interface IRequestLoggingService
{
    void Log(string url, long executionTimeMs, string operation = "GET");
    IReadOnlyList<RequestLogEntry> GetLogs();
}

public class RequestLogEntry
{
    public string Url { get; set; } = string.Empty;
    public long ExecutionTimeMs { get; set; }
    public DateTime Timestamp { get; set; }
    public string Operation { get; set; } = "GET";
}
