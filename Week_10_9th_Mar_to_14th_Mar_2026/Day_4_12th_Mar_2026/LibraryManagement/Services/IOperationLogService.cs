// Services/IOperationLogService.cs
using LibraryManagement.Models;

namespace LibraryManagement.Services;

public interface IOperationLogService
{
    void Log(string operation, string details, long executionTimeMs);
    IReadOnlyList<OperationLog> GetLogs();
}