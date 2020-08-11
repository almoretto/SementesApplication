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
        public PaginatedList<Entity> Entities { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name";
            ContactSort = String.IsNullOrEmpty(sortOrder) ? "cont_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Entity> entitiesIQ = from s in _context.Entity
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                entitiesIQ = entitiesIQ.Where(s => s.EntityName.Contains(searchString)
                                       || s.Contact.Contains(searchString));
            }
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

            int pageSize = 5;
            Entities = await PaginatedList<Entity>.CreateAsync(
                entitiesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
