using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class IndexEntity : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexEntity(SementesApplicationContext context)
        {
            _context = context;
        }

        public IList<Entity> Entity { get;set; }

        public async Task OnGetAsync()
        {
            Entity = await _context.Entity.ToListAsync();
        }
    }
}
