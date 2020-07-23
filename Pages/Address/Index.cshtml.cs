using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class IndexModelAddress : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public IndexModelAddress(SementesApplication.Data.SementesApplicationContext context)
        {
            _context = context;
        }

        public IList<Address> Address { get;set; }

        public async Task OnGetAsync()
        {
            Address = await _context.Address
                .Include(a => a.City).ToListAsync();
        }
    }
}
