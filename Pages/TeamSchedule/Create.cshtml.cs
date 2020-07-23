using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SementesApplication
{
    public class CreateModelTeamSchedule : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public CreateModelTeamSchedule(SementesApplication.Data.SementesApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["VolunteerId"] = new SelectList(_context.Volunteer, "VolunteerID", "VolunteerID");
            return Page();
        }

        [BindProperty]
        public TeamSchedule TeamSchedule { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TeamSchedule.Add(TeamSchedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
