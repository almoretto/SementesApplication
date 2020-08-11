using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class IndexJob : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexJob(SementesApplicationContext context)
        {
            _context = context;
        }
        public string JobDaySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Job> Jobs { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;

            JobDaySort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Job> jobsIQ = from s in _context.Job select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                jobsIQ = jobsIQ.Where(s => s.JobDay.Equals(searchString));
            }

            switch (sortOrder)
            {
                case "date_desc":
                    jobsIQ = jobsIQ.OrderByDescending(s => s.JobDay);
                    break;
                case "Date":
                    jobsIQ = jobsIQ.OrderBy(s => s.JobDay);
                    break;
                default:
                    jobsIQ = jobsIQ.OrderBy(s => s.Entity.EntityName);
                    break;
            }

            int pageSize = 5;
            Jobs = await PaginatedList<Job>.CreateAsync(
                jobsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
