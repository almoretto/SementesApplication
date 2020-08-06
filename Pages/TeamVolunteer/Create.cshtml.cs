using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SementesApplication.Data;

namespace SementesApplication
{
    public class CreateTeamVolunteer : PageModel
    {
        private readonly SementesApplicationContext _context;

        public CreateTeamVolunteer(SementesApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TeamId"] = new SelectList(_context.Team, "TeamId", "TeamId", "Team.JobId");
        ViewData["VolunteerId"] = new SelectList(_context.Volunteer, "VolunteerId", "VName");
            return Page();
        }

        [BindProperty]
        public TeamVolunteer TeamVolunteer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TeamVolunteer.Add(TeamVolunteer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
