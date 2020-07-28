using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class IndexModelVolunteer : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexModelVolunteer(SementesApplicationContext context)
        {
            _context = context;
        }

        public IList<Volunteer> Volunteer { get;set; }

        public async Task OnGetAsync()
        {
            Volunteer = await _context.Volunteer
                .Include(v => v.Address).ToListAsync();
        }
    }
}
