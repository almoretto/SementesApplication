using Microsoft.EntityFrameworkCore;



namespace SementesApplication.Data
{
    public class SementesApplicationContext : DbContext
    {
        public SementesApplicationContext(DbContextOptions<SementesApplicationContext> options)
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
        public DbSet<Entity> AssistedEntities { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Volunteer> Volunteer { get; set; }
        public DbSet<TeamSchedule> TeamSchedule { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<State> State { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasOne(p => p.State)
                .WithMany(b => b.Cities)
                .HasForeignKey(p => p.State.StateId);
            modelBuilder.Entity<Address>()
                .HasOne(p => p.City)
                .WithMany(b => b.Addresses)
                .HasForeignKey(p => p.City.CityID);
        }*/
    }
}
