using Microsoft.EntityFrameworkCore;



namespace SementesApplication.Data
{
    public class SementesApplicationContext : DbContext
    {
        public SementesApplicationContext (DbContextOptions<SementesApplicationContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=SementesApplicationContext;Integrated Security=True");
        }
        public DbSet<City> City { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<AssistedEntities> AssistedEntities { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Volunteer> Volunteer { get; set; }
        public DbSet<TeamSchedule> TeamSchedule { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<State> State { get; set; }

       
    }
}
