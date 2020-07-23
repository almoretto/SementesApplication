﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication;
using SementesApplication.Data;

namespace SementesApplication.Pages.TeamModel
{
    public class DetailsModel : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public DetailsModel(SementesApplication.Data.SementesApplicationContext context)
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

            Team = await _context.Team.FirstOrDefaultAsync(m => m.TeamID == id);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
