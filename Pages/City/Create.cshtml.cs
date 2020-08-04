using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SementesApplication.Data;

namespace SementesApplication
{
    public class CreateCity : PageModel
    {
        private readonly SementesApplicationContext _context;

        public CreateCity(SementesApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StateId"] = new SelectList(_context.State, "StateId", "StateId");
            return Page();
        }

        [BindProperty]
        public City City { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCity = new City();
            if (await TryUpdateModelAsync<City>(
                emptyCity,
                "City",   // Prefix for form value.
                s => s.CityName, s => s.StateId))
            {
                _context.City.Add(emptyCity);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
