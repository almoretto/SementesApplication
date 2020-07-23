using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SementesApplication
{
    public class CreateModelVolunteer : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public CreateModelVolunteer(SementesApplication.Data.SementesApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AddressID"] = new SelectList(_context.Address, "AddressID", "AddressID");
            return Page();
        }

        [BindProperty]
        public Volunteer Volunteer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Volunteer.Add(Volunteer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
