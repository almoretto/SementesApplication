using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class IndexState : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexState(SementesApplicationContext context)
        {
            _context = context;
        }

        public IList<State> State { get;set; }

        public async Task OnGetAsync()
        {
            State = await _context.State.ToListAsync();
        }
    }
}
