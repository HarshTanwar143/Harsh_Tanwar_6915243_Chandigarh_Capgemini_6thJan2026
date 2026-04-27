using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentManagementSystem.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string action = context.ActionDescriptor.DisplayName;
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[LOG] ▶ Action Started: {action} | Time: {time}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string action = context.ActionDescriptor.DisplayName;
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[LOG] ✔ Action Finished: {action} | Time: {time}");
        }
    }
}