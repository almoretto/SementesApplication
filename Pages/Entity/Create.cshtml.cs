using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SementesApplication.Data;

namespace SementesApplication
{
    public class CreateEntity : PageModel
    {
        private readonly SementesApplicationContext _context;

        public CreateEntity(SementesApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Entity Entity { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyEntity = new Entity();
            if (await TryUpdateModelAsync<Entity>(
                emptyEntity,
                "Entity",   // Prefix for form value.
                s => s.EntityName,
                s => s.VisitDay,
                s => s.VisitTime,
                s => s.VisitDuration,
                s => s.VisitScale,
                s => s.MaxVolunteer,
                s => s.Contact,
                s => s.Phone,
                s => s.Email))
            {
                _context.Entity.Add(emptyEntity);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
