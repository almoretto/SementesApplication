using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class DetailsCity : PageModel
    {
        private readonly SementesApplicationContext _context;

        public DetailsCity(SementesApplicationContext context)
        {
            _context = context;
        }

        public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.City.FirstOrDefaultAsync(m => m.CityID == id);

            if (City == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
