﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class DetailsModelJob : PageModel
    {
        private readonly SementesApplicationContext _context;

        public DetailsModelJob(SementesApplicationContext context)
        {
            _context = context;
        }

        public Job Job { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Job
                .Include(j => j.AssitedEntity)
                .Include(j => j.Team).FirstOrDefaultAsync(m => m.JobID == id);

            if (Job == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
