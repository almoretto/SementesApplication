using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication;
using SementesApplication.Data;

namespace SementesApplication
{
    public class IndexModelVolunteer : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public IndexModelVolunteer(SementesApplication.Data.SementesApplicationContext context)
        {
            _context = context;
        }

        public IList<Volunteer> Volunteer { get;set; }

        public async Task OnGetAsync()
        {
            Volunteer = await _context.Volunteer
                .Include(v => v.Address).ToListAsync();
        }
    }
}
