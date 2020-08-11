using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class IndexTeam : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexTeam(SementesApplicationContext context)
        {
            _context = context;
        }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Team> Teams { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            //NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Team> teamsIQ = from s in _context.Team
                                       where s.JobId == s.Job.JobId
                                       select s;
            IQueryable<Job> jobsIQ = from t in _context.Job
                                     where t.JobId == t.Team.JobId
                                     select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                teamsIQ = teamsIQ.Where(s => s.TeamId.Equals(searchString));
            }
            switch (sortOrder)
            {
                case "Date":
                    teamsIQ = teamsIQ.OrderBy(s => s.Job.JobDay);
                    break;
                case "date_desc":
                    jobsIQ = jobsIQ.OrderByDescending(t => t.JobDay);
                    break;
                default:
                    jobsIQ = jobsIQ.OrderBy(t => t.JobDay);
                    break;
            }

            int pageSize = 3;
            Teams = await PaginatedList<Team>.CreateAsync(
                teamsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
