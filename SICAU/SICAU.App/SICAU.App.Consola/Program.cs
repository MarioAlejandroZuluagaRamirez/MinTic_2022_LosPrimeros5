using System;
using System.Collections.Generic;
using SICAU.App.Dominio;
using SICAU.App.Persistencia;

namespace SICAU.App.Consola
{
    class Program
    {
        private static IRepositorioDirectivo _repoDirectivo = new RepositorioDirectivo(new Persistencia.AppContext());
        private static IRepositorioSede _repoSede = new RepositorioSede(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AddDirectivo();
            //AddSede();
            UpdateDirectivo(1);
        }

        public static void AddDirectivo()
        {
            var directivo = new Directivo()
            {
                nombre = "Jenny",
                apellido= "Bibiana",
                identificacion= "1022928550",
                fechaNacimiento = DateTime.Parse("1986-07-15"),
                estadoCovid= EstadoCovid.Negativo,
                unidad = "",
                sede = null
            };
           _repoDirectivo.AddDirectivo(directivo);
        }

        public static void AddSede()
        {
            var sede = new Sede()
            {
                sede = "Sede A",
                ubicacion= "Calle 65 No 67-99",
                universidad = null
            };
            _repoSede.AddSede(sede);
        }

        public static void UpdateDirectivo(int idDirectivo)
        {
            var sede = _repoSede.GetSede(1);
            var directivo = _repoDirectivo.GetDirectivo(idDirectivo);
            directivo.sede = sede;
            _repoDirectivo.UpdateDirectivo(directivo);
        }
    }
}