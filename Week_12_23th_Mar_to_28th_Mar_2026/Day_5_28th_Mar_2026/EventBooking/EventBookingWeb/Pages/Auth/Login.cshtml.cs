using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventBookingWeb.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration _config;

        public LoginModel(IConfiguration config)
        {
            _config = config;
        }

        public string ApiBase => _config["ApiBaseUrl"] ?? "https://localhost:7001";

        public void OnGet() { }
    }
}
