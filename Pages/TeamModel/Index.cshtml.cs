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
    public class IndexModel : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public IndexModel(SementesApplication.Data.SementesApplicationContext context)
        {
            _context = context;
        }

        public IList<Team> Team { get;set; }

        public async Task OnGetAsync()
        {
            Team = await _context.Team.ToListAsync();
        }
    }
}
