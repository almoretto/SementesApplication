using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SementesApplication.Data;

namespace SementesApplication
{
    public class CreateTeamSchedule : PageModel
    {
        private readonly SementesApplicationContext _context;

        public CreateTeamSchedule(SementesApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["VolunteerId"] = new SelectList(_context.Volunteer, "VolunteerId", "VName");
            return Page();
        }

        [BindProperty]
        public TeamSchedule TeamSchedule { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyTeamSchedule = new TeamSchedule();

            if (await TryUpdateModelAsync<TeamSchedule>(
                emptyTeamSchedule,
                "TeamSchedule",   // Prefix for form value.
                s => s.TSDate,
                s => s.TSPeriod,
                s => s.VolunteerId))

            {
                _context.TeamSchedule.Add(emptyTeamSchedule);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();

        }
    }
}
