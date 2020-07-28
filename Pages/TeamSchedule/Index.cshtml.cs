using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class IndexModelTeamSchedule : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexModelTeamSchedule(SementesApplicationContext context)
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
