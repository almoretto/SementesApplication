using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class EditAddress : PageModel
    {
        private readonly SementesApplicationContext _context;

        public EditAddress(SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Address Address { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Address = await _context.Address
                .Include(a => a.City).FirstAsync(m => m.AddressId == id);

            if (Address == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var addressToUpdate = await _context.Address.FindAsync(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (addressToUpdate == null)
            {
                return NotFound();
            }

            //_context.Attach(Address).State = EntityState.Modified;

            try
            {
                if (await TryUpdateModelAsync<Address>(
                    addressToUpdate,
                    "Address",
                    s => s.AddressKind,
                    s => s.Designation,
                    s => s.Complement,
                    s => s.District,
                    s=>s.CEP,
                    s => s.CityId))
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(Address.AddressId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Page();
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.AddressId == id);
        }
    }
}
