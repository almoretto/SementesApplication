using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class IndexAssistedEntities : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexAssistedEntities(SementesApplicationContext context)
        {
            _context = context;
        }

        public IList<AssistedEntities> AssistedEntities { get;set; }

        public async Task OnGetAsync()
        {
            AssistedEntities = await _context.AssistedEntities.ToListAsync();
        }
    }
}
