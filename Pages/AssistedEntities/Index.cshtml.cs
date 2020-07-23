using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class IndexModelAssistedEntities : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public IndexModelAssistedEntities(SementesApplication.Data.SementesApplicationContext context)
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
