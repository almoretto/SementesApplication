using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class EditVolunteer : PageModel
    {
        private readonly SementesApplicationContext _context;

        public EditVolunteer(SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Volunteer Volunteer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Volunteer = await _context.Volunteer
                .Include(v => v.Address).FirstAsync(m => m.VolunteerId == id);

            if (Volunteer == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "Designation");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var volunteerToUpdate = await _context.Volunteer.FindAsync(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (volunteerToUpdate == null)
            {
                return NotFound();
            }
            //_context.Attach(Volunteer).State = EntityState.Modified;

            try
            {
                if (await TryUpdateModelAsync<Volunteer>(
                    volunteerToUpdate,
                    "Volunteer",
                    s => s.VName,
                    s => s.VDocCPF,
                    s => s.VDocRG,
                    s => s.AddressId,
                    s => s.VActive,
                    s => s.VBirthDate,
                    s => s.VEmail,
                    s => s.VPhone,
                    s => s.VMessagePhone,
                    s => s.VResumee,
                    s => s.VSocialMidiaProfile))
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolunteerExists(Volunteer.VolunteerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Page();
            //return RedirectToPage("./Index");
        }

        private bool VolunteerExists(int id)
        {
            return _context.Volunteer.Any(e => e.VolunteerId == id);
        }
    }
}
