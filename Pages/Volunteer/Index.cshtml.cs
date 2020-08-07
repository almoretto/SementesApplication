﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class IndexVolunteer : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexVolunteer(SementesApplicationContext context)
        {
            _context = context;
        }

        public IList<Volunteer> Volunteer { get;set; }

        public async Task OnGetAsync()
        {
            Volunteer = await _context.Volunteer
                .Include(v => v.Address).ToListAsync();
            //Volunteer.OrderBy(Volunteer);
        }
    }
}
