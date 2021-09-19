using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioHorario : IRepositorioHorario
    {
        private readonly AppContext _appContext;

        public RepositorioHorario(AppContext appContext)
        {
            _appContext = appContext;
        }

        Horario IRepositorioHorario.AddHorario(Horario horario)
        {
            var horarioAdicionado = _appContext.horarios.Add(horario);
            _appContext.SaveChanges();
            return horarioAdicionado.Entity;
        }

        void IRepositorioHorario.DeleteHorario(int idHorario)
        {
            var horarioEncontrado = _appContext.horarios.FirstOrDefault(p => p.id == idHorario);
            if (horarioEncontrado == null)
                return;
            _appContext.horarios.Remove(horarioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Horario> IRepositorioHorario.GetAllHorario()
        {
            return _appContext.horarios;
        }

        Horario IRepositorioHorario.GetHorario(int idHorario)
        {
            return _appContext.horarios.FirstOrDefault(p => p.id == idHorario);
        }

        Horario IRepositorioHorario.UpdateHorario(Horario horario)
        {
            var horarioEncontrado = _appContext.horarios.FirstOrDefault(p => p.id == horario.id);
            if (horarioEncontrado != null)
            {
                horarioEncontrado.id = horario.id;
                horarioEncontrado.horaIngreso= horario.horaIngreso;
                horarioEncontrado.duracion = horario.duracion;
                horarioEncontrado.diaSemana = horario.diaSemana;
                horarioEncontrado.salon = horario.salon;
                 _appContext.SaveChanges();
            }
            return horarioEncontrado;
        }

    }
}