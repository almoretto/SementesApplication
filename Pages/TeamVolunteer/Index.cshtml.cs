using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class IndexTeamVolunteer : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexTeamVolunteer(SementesApplicationContext context)
        {
            _context = context;
        }

        public IList<TeamVolunteer> TeamVolunteer { get;set; }

        public async Task OnGetAsync()
        {
            TeamVolunteer = await _context.TeamVolunteer
                .Include(t => t.Team)
                .Include(t => t.Volunteer).ToListAsync();
        }
    }
}
