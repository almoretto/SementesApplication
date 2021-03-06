﻿using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class EditEntity : PageModel
    {
        private readonly SementesApplicationContext _context;

        public EditEntity(SementesApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entity Entity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entity = await _context.Entity.FirstAsync(m => m.EntityId == id);

            if (Entity == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var entityToUpdate = await _context.Entity.FindAsync(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (entityToUpdate == null)
            {
                return NotFound();
            }

            //_context.Attach(Entity).State = EntityState.Modified;

            try
            {
                if (await TryUpdateModelAsync<Entity>(
                    entityToUpdate,
                    "Entity",
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

                }
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(Entity.EntityId))
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

        private bool EntityExists(int id)
        {
            return _context.Entity.Any(e => e.EntityId == id);
        }
    }
}
