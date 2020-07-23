using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SementesApplication
{
    public class CreateModelJob : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public CreateModelJob(SementesApplication.Data.SementesApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AssistedEntitiesID"] = new SelectList(_context.AssistedEntities, "AssistedEntitiesID", "AssistedEntitiesID");
        ViewData["TeamID"] = new SelectList(_context.Set<Team>(), "TeamID", "TeamID");
            return Page();
        }

        [BindProperty]
        public Job Job { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Job.Add(Job);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
