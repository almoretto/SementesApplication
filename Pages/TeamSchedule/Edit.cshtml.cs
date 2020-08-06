using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class EditTeamSchedule : PageModel
    {
        private readonly SementesApplicationContext _context;

        public EditTeamSchedule(SementesApplicationContext context)
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
                .Include(t => t.Volunteer).FirstAsync(m => m.TeamScheduleId == id);

            if (TeamSchedule == null)
            {
                return NotFound();
            }
           ViewData["VolunteerId"] = new SelectList(_context.Volunteer, "VolunteerId", "VName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var teamScheduleToUpdate = await _context.TeamSchedule.FindAsync(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (teamScheduleToUpdate==null)
            {
                return NotFound();
            }

           // _context.Attach(TeamSchedule).State = EntityState.Modified;

            try
            {
                if (await TryUpdateModelAsync<TeamSchedule>(
                    teamScheduleToUpdate,
                    "TeamSchedule",
                    s=>s.TSDate,
                    s=>s.TSPeriod,
                    s=>s.VolunteerId))
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
               // await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamScheduleExists(TeamSchedule.TeamScheduleId))
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

        private bool TeamScheduleExists(int id)
        {
            return _context.TeamSchedule.Any(e => e.TeamScheduleId == id);
        }
    }
}
