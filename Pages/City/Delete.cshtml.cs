using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class DeleteModelCity : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public DeleteModelCity(SementesApplication.Data.SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.City.FindAsync(id);

            if (City != null)
            {
                _context.City.Remove(City);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
