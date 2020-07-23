using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class EditModelTeamSchedule : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public EditModelTeamSchedule(SementesApplication.Data.SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TeamSchedule TeamSchedule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamSchedule = await _context.TeamSchedule
                .Include(t => t.Volunteer).FirstOrDefaultAsync(m => m.TeamScheduleID == id);

            if (TeamSchedule == null)
            {
                return NotFound();
            }
           ViewData["VolunteerId"] = new SelectList(_context.Volunteer, "VolunteerID", "VolunteerID");
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

            _context.Attach(TeamSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamScheduleExists(TeamSchedule.TeamScheduleID))
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

        private bool TeamScheduleExists(int id)
        {
            return _context.TeamSchedule.Any(e => e.TeamScheduleID == id);
        }
    }
}
