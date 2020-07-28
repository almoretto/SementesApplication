using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class DetailsModelTeamSchedule : PageModel
    {
        private readonly SementesApplicationContext _context;

        public DetailsModelTeamSchedule(SementesApplicationContext context)
        {
            _context = context;
        }

        public TeamSchedule TeamSchedule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamSchedule = await _context.TeamSchedule
                .Include(t => t.Volunteer).FirstOrDefaultAsync(m => m.TeamScheduleID == id);

            if (TeamSchedule == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
