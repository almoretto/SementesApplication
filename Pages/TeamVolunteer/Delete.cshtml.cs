using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class DeleteTeamVolunteer : PageModel
    {
        private readonly SementesApplicationContext _context;

        public DeleteTeamVolunteer(SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TeamVolunteer TeamVolunteer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamVolunteer = await _context.TeamVolunteer
                .Include(t => t.Team)
                .Include(t => t.Volunteer).FirstOrDefaultAsync(m => m.TeamVolunteerId == id);

            if (TeamVolunteer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamVolunteer = await _context.TeamVolunteer.FindAsync(id);

            if (TeamVolunteer != null)
            {
                _context.TeamVolunteer.Remove(TeamVolunteer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
