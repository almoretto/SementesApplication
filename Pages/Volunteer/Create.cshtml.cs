using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SementesApplication.Data;

namespace SementesApplication
{
    public class CreateVolunteer : PageModel
    {
        private readonly SementesApplicationContext _context;

        public CreateVolunteer(SementesApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId");
            return Page();
        }

        [BindProperty]
        public Volunteer Volunteer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptySVolunteer = new Volunteer();
            if (await TryUpdateModelAsync<Volunteer>(
                emptySVolunteer,
                "Volunteer",   // Prefix for form value.
                s => s.VName,
                s => s.VDocCPF,
                s => s.VDocRG,
                s => s.AddressId,
                s=>s.VActive,
                s=>s.VBirthDate,
                s=>s.VEmail,
                s=>s.VPhone,
                s=>s.VMessagePhone,
                s=>s.VResumee,
                s=>s.VSocialMidiaProfile))
                
            {
                emptySVolunteer.AgeCalculator();
                _context.Volunteer.Add(emptySVolunteer);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
