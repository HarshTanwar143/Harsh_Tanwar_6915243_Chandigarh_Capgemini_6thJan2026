using EmployeeProjectApp.Data;
using EmployeeProjectApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProjectApp.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Projects
        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects
                .Include(p => p.EmployeeProjects)
                    .ThenInclude(ep => ep.Employee)
                        .ThenInclude(e => e.Department)
                .ToListAsync();

            return View(projects);
        }

        // GET: /Projects/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var project = await _context.Projects
                .Include(p => p.EmployeeProjects)
                    .ThenInclude(ep => ep.Employee)
                        .ThenInclude(e => e.Department)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null) return NotFound();
            return View(project);
        }

        // GET: /Projects/Create
        public IActionResult Create()
        {
            ViewBag.Employees = _context.Employees.Include(e => e.Department).ToList();
            return View();
        }

        // POST: /Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project, int[] selectedEmployees)
        {
            // FIX: Remove navigation property from validation
            ModelState.Remove("EmployeeProjects");

            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();

                foreach (var empId in selectedEmployees)
                {
                    _context.EmployeeProjects.Add(new EmployeeProject
                    {
                        ProjectId = project.Id,
                        EmployeeId = empId,
                        AssignedDate = DateTime.Now
                    });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Employees = _context.Employees.Include(e => e.Department).ToList();
            return View(project);
        }

        // GET: /Projects/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var project = await _context.Projects
                .Include(p => p.EmployeeProjects)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null) return NotFound();

            ViewBag.Employees = _context.Employees.Include(e => e.Department).ToList();
            ViewBag.SelectedEmployees = project.EmployeeProjects.Select(ep => ep.EmployeeId).ToList();
            return View(project);
        }

        // POST: /Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Project project, int[] selectedEmployees)
        {
            if (id != project.Id) return BadRequest();

            // FIX: Remove navigation property from validation
            ModelState.Remove("EmployeeProjects");

            if (ModelState.IsValid)
            {
                _context.Update(project);

                var existing = _context.EmployeeProjects.Where(ep => ep.ProjectId == id);
                _context.EmployeeProjects.RemoveRange(existing);

                foreach (var empId in selectedEmployees)
                {
                    _context.EmployeeProjects.Add(new EmployeeProject
                    {
                        ProjectId = id,
                        EmployeeId = empId,
                        AssignedDate = DateTime.Now
                    });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Employees = _context.Employees.Include(e => e.Department).ToList();
            return View(project);
        }

        // GET: /Projects/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return NotFound();
            return View(project);
        }

        // POST: /Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Projects/Dashboard
        public async Task<IActionResult> Dashboard()
        {
            ViewBag.EmployeesPerDepartment = await _context.Departments
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    Count = d.Employees.Count
                }).ToListAsync();

            var projects = await _context.Projects
                .Include(p => p.EmployeeProjects)
                    .ThenInclude(ep => ep.Employee)
                        .ThenInclude(e => e.Department)
                .ToListAsync();

            return View(projects);
        }
    }
}