using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class DetailsTeamVolunteer : PageModel
    {
        private readonly SementesApplicationContext _context;

        public DetailsTeamVolunteer(SementesApplicationContext context)
        {
            _context = context;
        }

        public TeamVolunteer TeamVolunteer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamVolunteer = await _context.TeamVolunteer
                .Include(t => t.Team)
                .Include(t => t.Volunteer)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TeamVolunteerId == id);

            if (TeamVolunteer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
