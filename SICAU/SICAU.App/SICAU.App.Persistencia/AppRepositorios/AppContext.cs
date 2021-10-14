using Microsoft.EntityFrameworkCore;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> personas { get; set; }
        public DbSet<Directivo> directivos { get; set; }
        public DbSet<PersonalAseo> personalAseos { get; set; }
        public DbSet<Estudiante> estudiantes { get; set; }
        public DbSet<Profesor> profesores { get; set; }
        public DbSet<Universidad> universidades { get; set; }
        public DbSet<Sede> sedes { get; set; }
        public DbSet<Salon> salones { get; set; }
        public DbSet<Facultad> facultades { get; set; }
        public DbSet<Programa> programas { get; set; }
        public DbSet<Materia> materias { get; set; }
        public DbSet<Horario> horarios { get; set; }
        public DbSet<Grupo> grupos { get; set; }
        public DbSet<EncuestaCovid> encuestaCovids { get; set; }
        public DbSet<Sintoma> sintomas { get; set; }
        public DbSet<EstudianteGrupo> estudianteGrupos { get; set; }
        public DbSet<EncuestaCovidSintoma> encuestaCovidSintomas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                // .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ProjectSICAUData");
                .UseSqlServer("Server=tcp:marioalejandro.database.windows.net,1433;Initial Catalog=SICAU;Persist Security Info=False;User ID=mazuluagar;Password=Alejo8776134;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
                // .EnableSensitiveDataLogging(true);
            }
        }
    }
}