using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class EditTeam : PageModel
    {
        private readonly SementesApplicationContext _context;

        public EditTeam(SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _context.Team
                .Include(t => t.Job).FirstAsync(m => m.TeamId == id);

            if (Team == null)
            {
                return NotFound();
            }
           ViewData["JobId"] = new SelectList(_context.Job, "JobId", "JobDay", "EntityId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var teamToUpdate = await _context.Team.FindAsync(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (teamToUpdate==null)
            {
                return NotFound();
            }
            //_context.Attach(Team).State = EntityState.Modified;

            try
            {
                if (await TryUpdateModelAsync<Team>(
                    teamToUpdate,
                    "Team",
                    s=>s.TeamVolunteer,
                    s=>s.JobId))
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(Team.TeamId))
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

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.TeamId == id);
        }
    }
}
