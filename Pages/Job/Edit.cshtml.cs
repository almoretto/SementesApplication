using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class EditJob : PageModel
    {
        private readonly SementesApplicationContext _context;

        public EditJob(SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Job Job { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Job
                .Include(j => j.Entity).FirstAsync(m => m.JobId == id);

            if (Job == null)
            {
                return NotFound();
            }
           ViewData["EntityId"] = new SelectList(_context.Entity, "EntityId", "EntityId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var jobToUpdate = await _context.Job.FindAsync(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (jobToUpdate==null)
            {
                return NotFound();
            }

            //_context.Attach(Job).State = EntityState.Modified;

            try
            {
                if (await TryUpdateModelAsync<Job>(
                    jobToUpdate,
                    "Job",
                    s=>s.JobDay,
                    s=>s.JobPeriod,
                    s=>s.ActionKind,
                    s=>s.MaxVolunteer,
                    s=>s.EntityId))
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                
                // await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(Job.JobId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //return RedirectToPage("./Index");
            return Page();
        }

        private bool JobExists(int id)
        {
            return _context.Job.Any(e => e.JobId == id);
        }
    }
}
