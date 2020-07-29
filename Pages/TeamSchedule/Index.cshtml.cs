using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class IndexTeamSchedule : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexTeamSchedule(SementesApplicationContext context)
        {
            _context = context;
        }

        public IList<TeamSchedule> TeamSchedule { get;set; }

        public async Task OnGetAsync()
        {
            TeamSchedule = await _context.TeamSchedule
                .Include(t => t.Volunteer).ToListAsync();
        }
    }
}
