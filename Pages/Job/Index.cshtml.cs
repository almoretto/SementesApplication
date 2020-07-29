﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    public class IndexJob : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexJob(SementesApplicationContext context)
        {
            _context = context;
        }

        public IList<Job> Job { get;set; }

        public async Task OnGetAsync()
        {
            Job = await _context.Job
                .Include(j => j.AssitedEntity)
                .Include(j => j.Team).ToListAsync();
        }
    }
}
