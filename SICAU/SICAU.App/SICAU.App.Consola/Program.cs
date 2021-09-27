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
        private static IRepositorioUniversidad _repoUniversidad = new RepositorioUniversidad(new Persistencia.AppContext());
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AddUniversidad();
            //AddSede();
            //UpdateSede();
            //AddDirectivo();
            //UpdateDirectivo();
            //AddProfesor();
        }
        public static void AddUniversidad()
        {
            var universidad = new Universidad()
            {
                universidad = "Universidad de Caldas"

            };
            _repoUniversidad.AddUniversidad(universidad);
        }

        public static void AddSede()
        {
            var sede0 = new Sede()
            {
                sede = "Principal",
                ubicacion= "Calle 65 26-10",
                universidad = null
            };
            _repoSede.AddSede(sede0);
            var sede1 = new Sede()
            {
                sede = "Palogrande",
                ubicacion= "Carrera 23 58-65",
                universidad = null
            };
            _repoSede.AddSede(sede1);
            var sede2 = new Sede()
            {
                sede = "Bellas Artes",
                ubicacion= "Carrera 21 13-02",
                universidad = null
            };
            _repoSede.AddSede(sede2);
            var sede3 = new Sede()
            {
                sede = "Sancansio",
                ubicacion= "Calle 65 30-65",
                universidad = null
            };
            _repoSede.AddSede(sede3);
            var sede4 = new Sede()
            {
                sede = "Versalles",
                ubicacion= "Carrera 25 48-57",
                universidad = null
            };
            _repoSede.AddSede(sede4);
        }

        public static void UpdateSede()
        {
            var universidad = _repoUniversidad.GetUniversidad(1);
            var sede = _repoSede.GetSede(1);
            sede.universidad = universidad;
            _repoSede.UpdateSede(sede);

            sede = _repoSede.GetSede(2);
            sede.universidad = universidad;
            _repoSede.UpdateSede(sede);

            sede = _repoSede.GetSede(3);
            sede.universidad = universidad;
            _repoSede.UpdateSede(sede);

            sede = _repoSede.GetSede(4);
            sede.universidad = universidad;
            _repoSede.UpdateSede(sede);

            sede = _repoSede.GetSede(5);
            sede.universidad = universidad;
            _repoSede.UpdateSede(sede);
        }


        public static void AddDirectivo()
        {
            var directivo0 = new Directivo()
            {
                nombre = "Mario Alejandro",
                apellido= "Zuluaga Ramirez",
                identificacion= "16070445",
                fechaNacimiento = DateTime.Parse("1982-03-01"),
                estadoCovid= EstadoCovid.Negativo,
                unidad = "",
                sede = null
            };
           _repoDirectivo.AddDirectivo(directivo0);
            var directivo1 = new Directivo()
            {
                nombre = "Jenny Bibiana",
                apellido= "Garcia Bohorquez",
                identificacion= "1022928550",
                fechaNacimiento = DateTime.Parse("1986-07-15"),
                estadoCovid= EstadoCovid.Negativo,
                unidad = "",
                sede = null
            };
           _repoDirectivo.AddDirectivo(directivo1);
        }

        public static void UpdateDirectivo()
        {
            var sede = _repoSede.GetSede(1);
            var directivo = _repoDirectivo.GetDirectivo(1);
            directivo.unidad = "Investigacion";
            directivo.sede = sede;
            _repoDirectivo.UpdateDirectivo(directivo);

            sede = _repoSede.GetSede(2);
            directivo = _repoDirectivo.GetDirectivo(2);
            directivo.unidad = "Admisiones";
            directivo.sede = sede;
            _repoDirectivo.UpdateDirectivo(directivo);
        }

        public static void AddProfesor()
        {
            var profesor0 = new Profesor()
            {
                nombre = "Mario Alejandro",
                apellido= "Zuluaga Ramirez",
                identificacion= "16070445",
                fechaNacimiento = DateTime.Parse("1982-03-01"),
                estadoCovid= EstadoCovid.Negativo,
                departamento = "Sistemas"
            };
           _repoProfesor.AddProfesor(profesor0);
            var profesor1 = new Profesor()
            {
                nombre = "Jenny Bibiana",
                apellido= "Garcia Bohorquez",
                identificacion= "1022928550",
                fechaNacimiento = DateTime.Parse("1986-07-15"),
                estadoCovid= EstadoCovid.Negativo,
                departamento = "Cartera"
            };
           _repoProfesor.AddProfesor(profesor1);
        }
    }
}