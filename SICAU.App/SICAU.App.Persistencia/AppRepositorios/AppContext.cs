using Microsoft.EntityFrameworkCore;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public class AppContext : DbContext
    {
            public DbSet<Encuesta> encuestas {get;set;} 
            public DbSet<Horario> horario {get;set;} 
            public DbSet<Sede> sede {get;set;} 
            
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SICAUData");
            }
        }
    }
}