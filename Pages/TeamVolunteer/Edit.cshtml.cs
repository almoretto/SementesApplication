using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class EditTeamVolunteer : PageModel
    {
        private readonly SementesApplicationContext _context;

        public EditTeamVolunteer(SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TeamVolunteer TeamVolunteer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamVolunteer = await _context.TeamVolunteer
                .Include(t => t.Team)
                .Include(t => t.Volunteer).FirstAsync(m => m.TeamVolunteerId == id);

            if (TeamVolunteer == null)
            {
                return NotFound();
            }
           ViewData["TeamId"] = new SelectList(_context.Team, "TeamId", "TeamId");
           ViewData["VolunteerId"] = new SelectList(_context.Volunteer, "VolunteerId", "Vname");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var teamVolunteerToUpdate = await _context.TeamVolunteer.FindAsync(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (teamVolunteerToUpdate==null)
            {
                return NotFound();
            }

            //_context.Attach(TeamVolunteer).State = EntityState.Modified;

            try
            {
                if (await TryUpdateModelAsync<TeamVolunteer>(
                    teamVolunteerToUpdate,
                    "TeamVolunteer",
                    s=>s.VolunteerId,
                    s=>s.TeamId))
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamVolunteerExists(TeamVolunteer.TeamVolunteerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Page();
           // return RedirectToPage("./Index");
        }

        private bool TeamVolunteerExists(int id)
        {
            return _context.TeamVolunteer.Any(e => e.TeamVolunteerId == id);
        }
    }
}
