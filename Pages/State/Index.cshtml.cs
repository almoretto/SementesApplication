using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class IndexState : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexState(SementesApplicationContext context)
        {
            _context = context;
        }
        public string UFNameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        //public IList<State> State { get; set; }
        public PaginatedList<State> States { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;

            UFNameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            
            IQueryable<State> stateIQ = from s in _context.State
                                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                stateIQ = stateIQ.Where(s => s.UFName.Contains(searchString)
                                       || s.UFAbreviation.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    stateIQ = stateIQ.OrderByDescending(s => s.UFName);
                    break;
                default:
                    stateIQ = stateIQ.OrderBy(s => s.UFName);
                    break;
            }
            int pageSize = 5;
            States = await PaginatedList<State>.CreateAsync(
                stateIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            //State = await stateIQ.AsNoTracking().ToListAsync();
            //State = await _context.State.ToListAsync();
        }
    }
}
