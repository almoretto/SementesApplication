using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class EditModelAssistedEntities : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public EditModelAssistedEntities(SementesApplication.Data.SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AssistedEntities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssistedEntitiesExists(AssistedEntities.AssistedEntitiesID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AssistedEntitiesExists(int id)
        {
            return _context.AssistedEntities.Any(e => e.AssistedEntitiesID == id);
        }
    }
}
