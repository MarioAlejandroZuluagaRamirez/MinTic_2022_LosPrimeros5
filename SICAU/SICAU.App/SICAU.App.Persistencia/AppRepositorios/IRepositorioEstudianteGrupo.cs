using System.Collections.Generic;
using SICAU.App.Dominio.Entidades;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioEstudianteGrupo
    {
        IEnumerable<EstudianteGrupo> GetAllEstudianteGrupo();
        EstudianteGrupo AddEstudianteGrupo(EstudianteGrupo estudianteGrupo);
        EstudianteGrupo UpdateEstudianteGrupo(EstudianteGrupo estudianteGrupo);
        void DeleteEstudianteGrupo(int idEstudianteGrupo);
        EstudianteGrupo GetEstudianteGrupo(int idEstudianteGrupo);
    }
}