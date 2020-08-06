using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class DeleteState : PageModel
    {
        private readonly SementesApplicationContext _context;

        public DeleteState(SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public State State { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            State = await _context.State.FirstOrDefaultAsync(m => m.StateId == id);

            if (State == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var state = await _context.State.FindAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            try
            {
                _context.State.Remove(state);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
            //State = await _context.State.FindAsync(id);

        }
    }
}
