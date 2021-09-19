using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioProfesor : IRepositorioProfesor
    {
        private readonly AppContext _appContext;

        public RepositorioProfesor(AppContext appContext)
        {
            _appContext = appContext;
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

