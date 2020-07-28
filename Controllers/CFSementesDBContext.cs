/*
 * using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SementesApplication
{
    public class CFSementesDBContext : DbContext
    {
        //O nome da cadeia de conexão (que você adicionará ao arquivo Web. config posteriormente) é passado para o construtor.
        public CFSementesDBContext() : base("CFSementesDBContext")
        {
        }

        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<AssistedEntities> AssistedEntities { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<TeamSchedule> TeamSchedules { get; set; }
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             //A instrução modelBuilder.Conventions.Remove no método OnModelCreating impede que nomes de tabela sejam pluraled. 
             // Se você não fez isso, as tabelas geradas no banco de dados seriam nomeadas Students, Coursese Enrollments. 
             // Em vez disso, os nomes de tabela serão Student, Coursee Enrollment.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}*/