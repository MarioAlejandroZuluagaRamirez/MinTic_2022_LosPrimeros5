using System.Collections.Generic;
using System.Linq;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public class RepositorioProfesor : IRepositorioProfesor
    {
        private readonly AppContext _appContext;
        public IEnumerable<Profesor> profesores;

        public RepositorioProfesor(AppContext appContext)
        {
            _appContext = appContext;
        }
		public RepositorioProfesor(IEnumerable<Profesor> profesores)
		{
		    this.profesores = profesores;
		}
		IEnumerable<Profesor> IRepositorioProfesor.GetByNames(string criterio)
		{
		    IEnumerable<Profesor> profesores = _appContext.profesores;

		    if (profesores != null
                && !string.IsNullOrEmpty(criterio))
		    {
			profesores = _appContext.profesores.Where(p => p.nombre.Contains(criterio) || p.apellido.Contains(criterio));
		    }
		    return profesores;
		}

        Profesor IRepositorioProfesor.AddProfesor(Profesor profesor)
        {
            var profesorAdicionado = _appContext.profesores.Add(profesor);
            _appContext.SaveChanges();
            return profesorAdicionado.Entity;
        }

        void IRepositorioProfesor.DeleteProfesor(int idProfesor)
        {
            var profesorEncontrado = _appContext.profesores.FirstOrDefault(p => p.id == idProfesor);
            if (profesorEncontrado == null)
                return;
            _appContext.profesores.Remove(profesorEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Profesor> IRepositorioProfesor.GetAllProfesor()
        {
            return _appContext.profesores;
        }

        Profesor IRepositorioProfesor.GetProfesor(int idProfesor)
        {
            return _appContext.profesores.FirstOrDefault(p => p.id == idProfesor);
        }

        Profesor IRepositorioProfesor.UpdateProfesor(Profesor profesor)
        {
            var profesorEncontrado = _appContext.profesores.FirstOrDefault(p => p.id == profesor.id);
            if (profesorEncontrado != null)
            {
                profesorEncontrado.id = profesor.id;
                profesorEncontrado.nombre = profesor.nombre;
                profesorEncontrado.apellido = profesor.apellido;
                profesorEncontrado.identificacion = profesor.identificacion;
                profesorEncontrado.fechaNacimiento = profesor.fechaNacimiento;
                profesorEncontrado.estadoCovid = profesor.estadoCovid;
                profesorEncontrado.departamento = profesor.departamento;
                 _appContext.SaveChanges();
            }
            return profesorEncontrado;
        }

    }
}

