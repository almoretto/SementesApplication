using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SementesApplication.Data;

namespace SementesApplication
{
    public class CreateTeam : PageModel
    {
        private readonly SementesApplicationContext _context;

        public CreateTeam(SementesApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "JobDate", "Job.Entity.EntityName");
            return Page();
        }

        [BindProperty]
        public Team Team { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyTeam = new Team();
            if (await TryUpdateModelAsync<Team>(
                emptyTeam,
                "Team",   // Prefix for form value.
                s => s.Volunteers))
            {
                _context.Team.Add(emptyTeam);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
