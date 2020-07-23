using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class DetailsModelAssistedEntities : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public DetailsModelAssistedEntities(SementesApplication.Data.SementesApplicationContext context)
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
