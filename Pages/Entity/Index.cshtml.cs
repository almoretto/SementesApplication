using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class IndexEntity : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexEntity(SementesApplicationContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string ContactSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<Entity> Entities { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name";
            ContactSort = String.IsNullOrEmpty(sortOrder) ? "cont_desc" : "";

            IQueryable<Entity> entitiesIQ = from s in _context.Entity
                                            select s;

            switch (sortOrder)
            {
                case "name_desc":
                    entitiesIQ = entitiesIQ.OrderByDescending(s => s.EntityName);
                    break;
                case "Date":
                    entitiesIQ = entitiesIQ.OrderBy(s => s.Contact);
                    break;
                default:
                    entitiesIQ = entitiesIQ.OrderBy(s => s.EntityName);
                    break;
            }

            Entities = await entitiesIQ.AsNoTracking().ToListAsync();
        }
    }
}
