using EventApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventApp.Pages.Events
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _context;

        public RegisterModel(AppDbContext context)
        {
            _context = context;
        }

        // ✅ [BindProperty] binds form input directly to this object
        [BindProperty]
        public EventRegistration Registration { get; set; }

        // GET: /Events/Register → just shows the empty form
        public void OnGet()
        {
        }

        // POST: /Events/Register → validates and saves to DB
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // stay on form, show errors
            }

            _context.EventRegistrations.Add(Registration);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"{Registration.ParticipantName} registered successfully!";
            return RedirectToPage("/Events/Index");
        }
    }
}