using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class DeleteCity : PageModel
    {
        private readonly SementesApplicationContext _context;

        public DeleteCity(SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public City City { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.City
                .Include(c => c.State).FirstOrDefaultAsync(m => m.CityId == id);

            if (City == null)
            {
                return NotFound();
            }
           
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }
            try
            {
                _context.City.Remove(city);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }

        }
    }
}
