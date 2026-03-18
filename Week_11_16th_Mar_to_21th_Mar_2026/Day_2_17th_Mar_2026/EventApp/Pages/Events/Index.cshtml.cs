using EventApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventApp.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        // ✅ List of registrations fetched from DB
        public List<EventRegistration> Registrations { get; set; }

        // GET: /Events/Index → fetch all from DB
        public void OnGet()
        {
            Registrations = _context.EventRegistrations.ToList();
        }

        // ✅ POST: Delete a participant by Id
        public IActionResult OnPostDelete(int id)
        {
            var registration = _context.EventRegistrations.Find(id);
            if (registration != null)
            {
                _context.EventRegistrations.Remove(registration);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Participant removed successfully!";
            }
            return RedirectToPage();
        }
    }
}