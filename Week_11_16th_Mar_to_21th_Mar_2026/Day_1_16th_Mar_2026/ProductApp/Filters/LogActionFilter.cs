using Microsoft.AspNetCore.Mvc.Filters;

namespace ProductApp.Filters
{
    public class LogActionFilter : IActionFilter
    {
        // Fires BEFORE the action runs
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string action = context.ActionDescriptor.DisplayName;
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[LOG] ▶ Action Started: {action} | Time: {time}");
        }

        // Fires AFTER the action runs
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string action = context.ActionDescriptor.DisplayName;
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[LOG] ✔ Action Finished: {action} | Time: {time}");
        }
    }
}