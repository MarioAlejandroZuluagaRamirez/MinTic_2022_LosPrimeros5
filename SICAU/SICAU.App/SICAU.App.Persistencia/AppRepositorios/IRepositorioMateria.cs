using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioMateria
    {
        IEnumerable<Materia> GetAllMateria();
        Materia AddMateria(Materia materia);
        Materia UpdateMateria(Materia materia);
        void DeleteMateria(int idMateria);
        Materia GetMateria(int idMateria);
    }
}