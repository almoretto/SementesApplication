﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class DetailsTeam : PageModel
    {
        private readonly SementesApplicationContext _context;

        public DetailsTeam(SementesApplicationContext context)
        {
            _context = context;
        }

        public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Navigation like a select
            Team = await _context.Team
                .Include(t => t.Job)
                .Include(e => e.TeamVolunteer)
                .Include(f => f.Volunteers)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TeamId == id);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
