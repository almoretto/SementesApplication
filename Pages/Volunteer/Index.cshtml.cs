using System;
using System.Collections.Generic;
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
        public string VNameSort { get; set; }
        public string VBirthDateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Volunteer> Volunteers { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;

            VNameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            VBirthDateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<Volunteer> volunteerIQ = from s in _context.Volunteer 
                                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                volunteerIQ = volunteerIQ.Where(s => s.VName.Contains(searchString)
                                       || s.VDocCPF.Contains(searchString));
            }
            /* Volunteer = await _context.Volunteer
                 .Include(v => v.Address).ToListAsync();
            */
            switch (sortOrder)
            {
                case "name_desc":
                    volunteerIQ = volunteerIQ.OrderByDescending(s => s.VName);
                    break;
                case "Date":
                    volunteerIQ = volunteerIQ.OrderBy(s => s.VBirthDate);
                    break;
                case "date_desc":
                    volunteerIQ = volunteerIQ.OrderByDescending(s => s.VBirthDate);
                    break;
                default:
                    volunteerIQ = volunteerIQ.OrderBy(s => s.VName);
                    break;
            }

            //Volunteers = await volunteerIQ.AsNoTracking().ToListAsync();
            int pageSize = 3;
            Volunteers = await PaginatedList<Volunteer>
                .CreateAsync(volunteerIQ.AsNoTracking(),
                pageIndex ?? 1, 
                pageSize);
            //Volunteer.OrderBy(Volunteer);
        }
    }
}
