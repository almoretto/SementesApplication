using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication;
using SementesApplication.Data;

namespace SementesApplication.Pages.AssistedEntitesModel
{
    public class DeleteModel : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public DeleteModel(SementesApplication.Data.SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AssistedEntities AssistedEntities { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AssistedEntities = await _context.AssistedEntities.FirstOrDefaultAsync(m => m.AssistedEntitiesID == id);

            if (AssistedEntities == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AssistedEntities = await _context.AssistedEntities.FindAsync(id);

            if (AssistedEntities != null)
            {
                _context.AssistedEntities.Remove(AssistedEntities);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
