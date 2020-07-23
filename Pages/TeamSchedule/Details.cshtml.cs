using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class DetailsModelTeamSchedule : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public DetailsModelTeamSchedule(SementesApplication.Data.SementesApplicationContext context)
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
