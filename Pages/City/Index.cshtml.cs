﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SementesApplication
{
    /// <summary>
    ///City Indexcshtml.cs 
    /// </summary>
    public class IndexModelCity : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexModelCity(SementesApplicationContext context)
        {
            _context = context;
        }

        public IList<City> City { get;set; }

        public async Task OnGetAsync()
        {
            City = await _context.City.ToListAsync();
        }
    }
}
