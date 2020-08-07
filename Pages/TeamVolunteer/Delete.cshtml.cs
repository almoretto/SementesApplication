using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class DeleteTeamVolunteer : PageModel
    {
        private readonly SementesApplicationContext _context;

        public DeleteTeamVolunteer(SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TeamVolunteer TeamVolunteer { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamVolunteer = await _context.TeamVolunteer
                .Include(t => t.Team)
                .Include(t => t.Volunteer).FirstOrDefaultAsync(m => m.TeamVolunteerId == id);

            if (TeamVolunteer == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Coldn´t Delete de Record id: " + id;

            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamVolunteer = await _context.TeamVolunteer.FindAsync(id);

            try
            {
                _context.TeamVolunteer.Remove(teamVolunteer);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");

            }
            catch (DbUpdateException ex)
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(ErrorMessage);
                sb.AppendLine(ex.ToString());

                ErrorMessage = sb.ToString();
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }

            /*if (TeamVolunteer != null)
            {
                _context.TeamVolunteer.Remove(TeamVolunteer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");*/
        }
    }
}
