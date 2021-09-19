using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioEstudiante : IRepositorioEstudiante
    {
        private readonly AppContext _appContext;

        public RepositorioEstudiante(AppContext appContext)
        {
            _appContext = appContext;
        }

        Estudiante IRepositorioEstudiante.AddEstudiante(Estudiante estudiante)
        {
            var estudianteAdicionado = _appContext.estudiantes.Add(estudiante);
            _appContext.SaveChanges();
            return estudianteAdicionado.Entity;
        }

        void IRepositorioEstudiante.DeleteEstudiante(int idEstudiante)
        {
            var estudianteEncontrado = _appContext.estudiantes.FirstOrDefault(p => p.id == idEstudiante);
            if (estudianteEncontrado == null)
                return;
            _appContext.estudiantes.Remove(estudianteEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Estudiante> IRepositorioEstudiante.GetAllEstudiante()
        {
            return _appContext.estudiantes;
        }

        Estudiante IRepositorioEstudiante.GetEstudiante(int idEstudiante)
        {
            return _appContext.estudiantes.FirstOrDefault(p => p.id == idEstudiante);
        }

        Estudiante IRepositorioEstudiante.UpdateEstudiante(Estudiante estudiante)
        {
            var estudianteEncontrado = _appContext.estudiantes.FirstOrDefault(p => p.id == estudiante.id);
            if (estudianteEncontrado != null)
            {
                estudianteEncontrado.id = estudiante.id;
                estudianteEncontrado.nombre = estudiante.nombre;
                estudianteEncontrado.apellido = estudiante.apellido;
                estudianteEncontrado.identificacion = estudiante.identificacion;
                estudianteEncontrado.fechaNacimiento = estudiante.fechaNacimiento;
                estudianteEncontrado.estadoCovid = estudiante.estadoCovid;
                estudianteEncontrado.semestre = estudiante.semestre;
                estudianteEncontrado.programa = estudiante.programa;
                 _appContext.SaveChanges();
            }
            return estudianteEncontrado;
        }

    }
}

