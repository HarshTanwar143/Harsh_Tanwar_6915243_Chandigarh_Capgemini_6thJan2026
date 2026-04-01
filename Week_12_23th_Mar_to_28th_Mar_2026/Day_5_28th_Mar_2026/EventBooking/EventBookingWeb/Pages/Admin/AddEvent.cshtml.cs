using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventBookingWeb.Pages.Admin
{
    public class AddEventModel : PageModel
    {
        private readonly IConfiguration _config;

        public AddEventModel(IConfiguration config)
        {
            _config = config;
        }

        public string ApiBase => _config["ApiBaseUrl"] ?? "https://localhost:7001";

        public void OnGet() { }
    }
}
