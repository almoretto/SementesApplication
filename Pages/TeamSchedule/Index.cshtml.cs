using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SementesApplication.Data;

namespace SementesApplication
{
    public class IndexTeamSchedule : PageModel
    {
        private readonly SementesApplicationContext _context;

        public IndexTeamSchedule(SementesApplicationContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<TeamSchedule> TeamSchedulers { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
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

            IQueryable<TeamSchedule> teamScheduleIQ = from s in _context.TeamSchedule
                                                      select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                teamScheduleIQ = teamScheduleIQ.Where(s => s.Volunteer.VName.Contains(searchString)
                                       || s.TSDate.Equals(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    teamScheduleIQ = teamScheduleIQ.OrderByDescending(s => s.Volunteer.VName);
                    break;
                case "Date":
                    teamScheduleIQ = teamScheduleIQ.OrderBy(s => s.TSDate);
                    break;
                case "date_desc":
                    teamScheduleIQ = teamScheduleIQ.OrderByDescending(s => s.TSDate);
                    break;
                default:
                    teamScheduleIQ = teamScheduleIQ.OrderBy(s => s.Volunteer.VName);
                    break;
            }
            int pageSize = 3;
            TeamSchedulers = await PaginatedList<TeamSchedule>.CreateAsync(
                teamScheduleIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
