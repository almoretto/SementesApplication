using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class DetailsAssistedEntities : PageModel
    {
        private readonly SementesApplicationContext _context;

        public DetailsAssistedEntities(SementesApplicationContext context)
        {
            _context = context;
        }

        public AssistedEntities AssistedEntities { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AssistedEntities = await _context.AssistedEntities.FirstOrDefaultAsync(m => m.AssistedEntitiesID == id);

            if (AssistedEntities == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
