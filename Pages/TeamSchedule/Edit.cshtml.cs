﻿using System.Linq;
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
                .Include(t => t.Volunteer).FirstOrDefaultAsync(m => m.TeamScheduleId == id);

            if (TeamSchedule == null)
            {
                return NotFound();
            }
           ViewData["VolunteerId"] = new SelectList(_context.Volunteer, "VolunteerId", "VolunteerId");
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
                if (!TeamScheduleExists(TeamSchedule.TeamScheduleId))
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
            return _context.TeamSchedule.Any(e => e.TeamScheduleId == id);
        }
    }
}