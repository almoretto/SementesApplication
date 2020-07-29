using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class IndexVolunteer : PageModel
    {
        private readonly SementesApplication.SementesApplicationContext _context;

        public IndexVolunteer(SementesApplication.SementesApplicationContext context)
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
