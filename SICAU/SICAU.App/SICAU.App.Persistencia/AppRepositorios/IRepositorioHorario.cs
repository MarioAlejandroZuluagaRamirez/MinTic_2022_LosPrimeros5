using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioHorario
    {
        IEnumerable<Horario> GetAllHorario();
        Horario AddHorario(Horario horario);
        Horario UpdateHorario(Horario horario);
        void DeleteHorario(int idHorario);
        Horario GetHorario(int idHorario);
    }
}