using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SementesApplication;

namespace SementesApplication.Data
{
    public class SementesApplicationContext : DbContext
    {
        public SementesApplicationContext (DbContextOptions<SementesApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<SementesApplication.City> City { get; set; }

        public DbSet<SementesApplication.Address> Address { get; set; }

        public DbSet<SementesApplication.Volunteer> Volunteer { get; set; }

        public DbSet<SementesApplication.TeamSchedule> TeamSchedule { get; set; }

        public DbSet<SementesApplication.Team> Team { get; set; }

        public DbSet<SementesApplication.AssistedEntities> AssistedEntities { get; set; }

        public DbSet<SementesApplication.Actions> Actions { get; set; }
    }
}
