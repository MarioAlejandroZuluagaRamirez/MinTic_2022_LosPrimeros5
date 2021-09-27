using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        private static IRepositorioFacultad _repoFacultad = new RepositorioFacultad(new Persistencia.AppContext());
        private static IRepositorioPrograma _repoPrograma = new RepositorioPrograma(new Persistencia.AppContext());
        private static IRepositorioEstudiante _repoEstudiante = new RepositorioEstudiante(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AddUniversidad();
            //AddSede();
            //UpdateSede();
            //AddDirectivo();
            //UpdateDirectivo();
            //AddProfesor();
            //AddEstudiante();
            //AddFacultad();
            //AddPrograma();
            //UpdateEstudiante();
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

        public static void AddFacultad()
        {
            var facultad0 = new Facultad()
            {
                facultad = "Facultad de Artes y Humanidades"
            };
            _repoFacultad.AddFacultad(facultad0);
            var facultad1 = new Facultad()
            {
                facultad = "Facultad de Ciencias Agropecuarias"
            };
            _repoFacultad.AddFacultad(facultad1);
            var facultad2 = new Facultad()
            {
                facultad = "Facultad de Ciencias Exactas y Naturales"
            };
            _repoFacultad.AddFacultad(facultad2);
            var facultad3 = new Facultad()
            {
                facultad = "Facultad de Ciencias Jurídicas y Sociales"
            };
            _repoFacultad.AddFacultad(facultad3);
            var facultad4 = new Facultad()
            {
                facultad = "Facultad de Ciencias para la Salud"
            };
            _repoFacultad.AddFacultad(facultad4);
            var facultad5 = new Facultad()
            {
                facultad = "Facultad de Ingeniería"
            };
            _repoFacultad.AddFacultad(facultad5);
        }

        public static void AddPrograma()
        {
            Programa programa0 = new Programa()
            {
                programa = "Ingeniería de Alimentos",
                facultad = "Facultad de Ingeniería"
            };
            _repoPrograma.AddPrograma(programa0);
            Programa programa1 = new Programa()
            {
                programa = "Ingeniería de Sistemas y Computación",
                facultad = "Facultad de Ingeniería"
            };
            _repoPrograma.AddPrograma(programa1);
            Programa programa2 = new Programa()
            {
                programa = "Ingeniería Informatica",
                facultad = "Facultad de Ingeniería"
            };
            _repoPrograma.AddPrograma(programa2);
        }

        public static void UpdatePrograma()
        {
            // var facultad = _repoFacultad.GetFacultad(6);
            // var programa0 = _repoPrograma.GetPrograma(1);
            // _repoPrograma.UpdatePrograma(programa0);

            // var programa1 = _repoPrograma.GetPrograma(2);
            // programa1.facultad = facultad.facultad;
            // _repoPrograma.UpdatePrograma(programa1);

            // var programa2 = _repoPrograma.GetPrograma(3);
            // programa2.facultad = facultad.facultad;
            // _repoPrograma.UpdatePrograma(programa2);
        }


        public static void AddDirectivo()
        {
            var directivo0 = new Directivo()
            {
                nombre = "",
                apellido= "",
                identificacion= "",
                fechaNacimiento = DateTime.Parse(""),
                estadoCovid= EstadoCovid.Negativo,
                unidad = "",
                sede = null
            };
           _repoDirectivo.AddDirectivo(directivo0);
            var directivo1 = new Directivo()
            {
                nombre = "",
                apellido= "",
                identificacion= "",
                fechaNacimiento = DateTime.Parse(""),
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
                nombre = "",
                apellido= "",
                identificacion= "",
                fechaNacimiento = DateTime.Parse(""),
                estadoCovid= EstadoCovid.Negativo,
                departamento = ""
            };
           _repoProfesor.AddProfesor(profesor0);
            var profesor1 = new Profesor()
            {
                nombre = "",
                apellido= "",
                identificacion= "",
                fechaNacimiento = DateTime.Parse(""),
                estadoCovid= EstadoCovid.Negativo,
                departamento = ""
            };
           _repoProfesor.AddProfesor(profesor1);
        }

        public static void AddEstudiante()
        {
            var estudiante0 = new Estudiante()
            {
                nombre = "Mario Alejandro",
                apellido= "Zuluaga Ramirez",
                identificacion= "16070445",
                fechaNacimiento = DateTime.Parse("1982-03-01"),
                estadoCovid= EstadoCovid.Negativo,
                semestre = Semestre.I,
                programa = null
            };
           _repoEstudiante.AddEstudiante(estudiante0);
            var estudiante1 = new Estudiante()
            {
                nombre = "Jenny Bibiana",
                apellido= "Garcia Bohorquez",
                identificacion= "1022928550",
                fechaNacimiento = DateTime.Parse("1986-07-15"),
                estadoCovid= EstadoCovid.Negativo,
                semestre = Semestre.II,
                programa = null
            };
           _repoEstudiante.AddEstudiante(estudiante1);
        }

        public static void UpdateEstudiante()
        {
            var programa = _repoPrograma.GetPrograma(9);
            var estudiante0 = _repoEstudiante.GetEstudiante(5);
            estudiante0.programa = programa;
            _repoEstudiante.UpdateEstudiante(estudiante0);

            var estudiante1 = _repoEstudiante.GetEstudiante(6);
            estudiante1.programa = programa;
            _repoEstudiante.UpdateEstudiante(estudiante1);
        }
    }
}