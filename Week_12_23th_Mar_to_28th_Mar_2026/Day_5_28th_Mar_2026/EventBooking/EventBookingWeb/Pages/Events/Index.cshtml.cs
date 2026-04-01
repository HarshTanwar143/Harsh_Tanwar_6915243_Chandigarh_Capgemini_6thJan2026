using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventBookingWeb.Pages.Events
{
    public class EventsIndexModel : PageModel
    {
        private readonly IConfiguration _config;

        public EventsIndexModel(IConfiguration config)
        {
            _config = config;
        }

        public string ApiBase => _config["ApiBaseUrl"] ?? "https://localhost:7001";

        public void OnGet() { }
    }
}
