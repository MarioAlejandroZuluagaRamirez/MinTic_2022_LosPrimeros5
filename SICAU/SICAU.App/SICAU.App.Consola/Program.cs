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
        private static IRepositorioPersonalAseo _repoPersonalAseo = new RepositorioPersonalAseo(new Persistencia.AppContext());
        private static IRepositorioSalon _repoSalon = new RepositorioSalon(new Persistencia.AppContext());
        private static IRepositorioMateria _repoMateria = new RepositorioMateria(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // AddUniversidad();
            // AddSede();
            // UpdateSede();
            // AddSalon();
            // UpdateSalon();
            // AddFacultad();
            // UpdateFacultad();
            // AddPrograma();
            // UpdatePrograma();
            // AddEstudiante();
            // UpdateEstudiante();
            // AddDirectivo();
            // UpdateDirectivo();
            // AddProfesor();
            // UpdateProfesor();
            // AddPersonalAseo();
            // UpdatePersonalAseo();
            // AddMateria();
            // UpdateMateria();
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
        public static void AddSalon()
        {
            Salon salon0 = new Salon()
            {
                numero = "101",
                capacidad = 35
            };
            _repoSalon.AddSalon(salon0);
            Salon salon1 = new Salon()
            {
                numero = "102",
                capacidad = 35
            };
            _repoSalon.AddSalon(salon1);
            Salon salon2 = new Salon()
            {
                numero = "103",
                capacidad = 35
            };
            _repoSalon.AddSalon(salon2);
            Salon salon3 = new Salon()
            {
                numero = "201",
                capacidad = 20
            };
            _repoSalon.AddSalon(salon3);
            Salon salon4 = new Salon()
            {
                numero = "202",
                capacidad = 20
            };
            _repoSalon.AddSalon(salon4);
            Salon salon5 = new Salon()
            {
                numero = "203",
                capacidad = 20
            };
            _repoSalon.AddSalon(salon5);
            Salon salon6 = new Salon()
            {
                numero = "301",
                capacidad = 30
            };
            _repoSalon.AddSalon(salon6);
            Salon salon7 = new Salon()
            {
                numero = "302",
                capacidad = 30
            };
            _repoSalon.AddSalon(salon7);
            Salon salon8 = new Salon()
            {
                numero = "303",
                capacidad = 30
            };
            _repoSalon.AddSalon(salon8);
            Salon salon9 = new Salon()
            {
                numero = "401",
                capacidad = 50
            };
            _repoSalon.AddSalon(salon9);

        }
        public static void UpdateSalon()
        {
            Salon salon;
            Sede sede = _repoSede.GetSede(1);
            salon = _repoSalon.GetSalon(1);
            salon.sede = sede;
            _repoSalon.UpdateSalon(salon);
            salon = _repoSalon.GetSalon(2);
            salon.sede = sede;
            _repoSalon.UpdateSalon(salon);
            salon = _repoSalon.GetSalon(3);
            salon.sede = sede;
            _repoSalon.UpdateSalon(salon);
            salon = _repoSalon.GetSalon(4);
            salon.sede = sede;
            _repoSalon.UpdateSalon(salon);
            salon = _repoSalon.GetSalon(5);
            salon.sede = sede;
            _repoSalon.UpdateSalon(salon);
            salon = _repoSalon.GetSalon(6);
            salon.sede = sede;
            _repoSalon.UpdateSalon(salon);
            salon = _repoSalon.GetSalon(7);
            salon.sede = sede;
            _repoSalon.UpdateSalon(salon);
            salon = _repoSalon.GetSalon(8);
            salon.sede = sede;
            _repoSalon.UpdateSalon(salon);
            salon = _repoSalon.GetSalon(9);
            salon.sede = sede;
            _repoSalon.UpdateSalon(salon);
            salon = _repoSalon.GetSalon(10);
            salon.sede = sede;
            _repoSalon.UpdateSalon(salon);
        }
        public static void AddFacultad()
        {
            Universidad universidad = _repoUniversidad.GetUniversidad(1);
            Facultad facultad0 = new Facultad()
            {
                facultad = "Facultad de Artes y Humanidades"
            };
            _repoFacultad.AddFacultad(facultad0);
            Facultad facultad1 = new Facultad()
            {
                facultad = "Facultad de Ciencias Agropecuarias"
            };
            _repoFacultad.AddFacultad(facultad1);
            Facultad facultad2 = new Facultad()
            {
                facultad = "Facultad de Ciencias Exactas y Naturales"
            };
            _repoFacultad.AddFacultad(facultad2);
            Facultad facultad3 = new Facultad()
            {
                facultad = "Facultad de Ciencias Jurídicas y Sociales"
            };
            _repoFacultad.AddFacultad(facultad3);
            Facultad facultad4 = new Facultad()
            {
                facultad = "Facultad de Ciencias para la Salud"
            };
            _repoFacultad.AddFacultad(facultad4);
            Facultad facultad5 = new Facultad()
            {
                facultad = "Facultad de Ingeniería"
            };
            _repoFacultad.AddFacultad(facultad5);
        }
        public static void UpdateFacultad()
        {
            Universidad universidad = _repoUniversidad.GetUniversidad(1);
            Facultad facultad;
            
            facultad = _repoFacultad.GetFacultad(1);
            facultad.universidad = universidad;
            _repoFacultad.UpdateFacultad(facultad);

            facultad = _repoFacultad.GetFacultad(2);
            facultad.universidad = universidad;
            _repoFacultad.UpdateFacultad(facultad);

            facultad = _repoFacultad.GetFacultad(3);
            facultad.universidad = universidad;
            _repoFacultad.UpdateFacultad(facultad);

            facultad = _repoFacultad.GetFacultad(4);
            facultad.universidad = universidad;
            _repoFacultad.UpdateFacultad(facultad);

            facultad = _repoFacultad.GetFacultad(5);
            facultad.universidad = universidad;
            _repoFacultad.UpdateFacultad(facultad);

            facultad = _repoFacultad.GetFacultad(6);
            facultad.universidad = universidad;
            _repoFacultad.UpdateFacultad(facultad);
        }
        public static void AddPrograma()
        {
            Programa programa0 = new Programa()
            {
                programa = "Ingeniería de Alimentos",
            };
            _repoPrograma.AddPrograma(programa0);
            Programa programa1 = new Programa()
            {
                programa = "Ingeniería de Sistemas y Computación",
            };
            _repoPrograma.AddPrograma(programa1);
            Programa programa2 = new Programa()
            {
                programa = "Ingeniería Informatica",
            };
            _repoPrograma.AddPrograma(programa2);
        }
        public static void UpdatePrograma()
        {
            Facultad facultad = _repoFacultad.GetFacultad(6);
            Programa programa0 = _repoPrograma.GetPrograma(1);
            programa0.facultad = facultad;
            _repoPrograma.UpdatePrograma(programa0);

            Programa programa1 = _repoPrograma.GetPrograma(2);
            programa1.facultad = facultad;
            _repoPrograma.UpdatePrograma(programa1);

            Programa programa2 = _repoPrograma.GetPrograma(3);
            programa2.facultad = facultad;
            _repoPrograma.UpdatePrograma(programa2);
        }
        public static void AddEstudiante()
        {
            Estudiante estudiante0 = new Estudiante()
            {
                nombre = "Mario Alejandro",
                apellido = "Zuluaga Ramirez",
                identificacion = "16070445",
                fechaNacimiento = DateTime.Parse("1982-03-01"),
                estadoCovid = EstadoCovid.Negativo,
                semestre = Semestre.I,
                programa = null
            };
            _repoEstudiante.AddEstudiante(estudiante0);
            Estudiante estudiante1 = new Estudiante()
            {
                nombre = "Jenny Bibiana",
                apellido = "Garcia Bohorquez",
                identificacion = "12345678",
                fechaNacimiento = DateTime.Parse("1986-07-15"),
                estadoCovid = EstadoCovid.Negativo,
                semestre = Semestre.II,
                programa = null
            };
            _repoEstudiante.AddEstudiante(estudiante1);
        }
        public static void UpdateEstudiante()
        {
            Programa programa = _repoPrograma.GetPrograma(3);
            Estudiante estudiante0 = _repoEstudiante.GetEstudiante(1);
            estudiante0.programa = programa;
            _repoEstudiante.UpdateEstudiante(estudiante0);

            Estudiante estudiante1 = _repoEstudiante.GetEstudiante(2);
            estudiante1.programa = programa;
            _repoEstudiante.UpdateEstudiante(estudiante1);
        }
        public static void AddDirectivo()
        {
            Directivo directivo0 = new Directivo()
            {
                nombre = "Mario Alejandro",
                apellido = "Zuluaga Ramirez",
                identificacion = "16070445",
                fechaNacimiento = DateTime.Parse("1982-03-01"),
                estadoCovid = EstadoCovid.Negativo,
                unidad = "",
                sede = null
            };
           _repoDirectivo.AddDirectivo(directivo0);
            Directivo directivo1 = new Directivo()
            {
                nombre = "Jenny Bibiana",
                apellido = "Garcia Bohorquez",
                identificacion = "12345678",
                fechaNacimiento = DateTime.Parse("1986-07-15"),
                estadoCovid = EstadoCovid.Negativo,
                unidad = "",
                sede = null
            };
           _repoDirectivo.AddDirectivo(directivo1);
        }
        public static void UpdateDirectivo()
        {
            Sede sede = _repoSede.GetSede(1);
            Directivo directivo = _repoDirectivo.GetDirectivo(3);
            directivo.unidad = "Investigacion";
            directivo.sede = sede;
            _repoDirectivo.UpdateDirectivo(directivo);

            sede = _repoSede.GetSede(2);
            directivo = _repoDirectivo.GetDirectivo(4);
            directivo.unidad = "Admisiones";
            directivo.sede = sede;
            _repoDirectivo.UpdateDirectivo(directivo);
        }
        public static void AddProfesor()
        {
            Profesor profesor0 = new Profesor()
            {
                nombre = "Mario Alejandro",
                apellido = "Zuluaga Ramirez",
                identificacion = "16070445",
                fechaNacimiento = DateTime.Parse("1982-03-01"),
                estadoCovid = EstadoCovid.Negativo,
                departamento = ""
            };
           _repoProfesor.AddProfesor(profesor0);
            Profesor profesor1 = new Profesor()
            {
                nombre = "Jenny Bibiana",
                apellido = "Garcia Bohorquez",
                identificacion = "12345678",
                fechaNacimiento = DateTime.Parse("1986-07-15"),
                estadoCovid = EstadoCovid.Negativo,
                departamento = ""
            };
           _repoProfesor.AddProfesor(profesor1);
        }
        public static void UpdateProfesor()
        {
            Profesor profesor;
            profesor = _repoProfesor.GetProfesor(5);
            profesor.departamento = "Investigación";
            _repoProfesor.UpdateProfesor(profesor);
            profesor = _repoProfesor.GetProfesor(6);
            profesor.departamento = "Admisiones";
            _repoProfesor.UpdateProfesor(profesor);
        }
        public static void AddPersonalAseo()
        {
            PersonalAseo personalAseo0 = new PersonalAseo()
            {
                nombre = "Mario Alejandro",
                apellido= "Zuluaga Ramirez",
                identificacion= "16070445",
                fechaNacimiento = DateTime.Parse("1982-03-01"),
                estadoCovid= EstadoCovid.Negativo,
                turno = Turno.Mañana,
                sede = null
            };
           _repoPersonalAseo.AddPersonalAseo(personalAseo0);
            PersonalAseo personalAseo1 = new PersonalAseo()
            {
                nombre = "Jenny Bibiana",
                apellido= "Garcia Bohorquez",
                identificacion= "12345678",
                fechaNacimiento = DateTime.Parse("1986-07-15"),
                estadoCovid= EstadoCovid.Negativo,
                turno = Turno.Tarde,
                sede = null
            };
           _repoPersonalAseo.AddPersonalAseo(personalAseo1);
        }
        public static void UpdatePersonalAseo()
        {
            Sede sede0 = _repoSede.GetSede(1);
            PersonalAseo personalAseo0 = _repoPersonalAseo.GetPersonalAseo(7);
            personalAseo0.sede = sede0;
            _repoPersonalAseo.UpdatePersonalAseo(personalAseo0);
            
            Sede sede1 = _repoSede.GetSede(2);
            PersonalAseo personalAseo1 = _repoPersonalAseo.GetPersonalAseo(8);
            personalAseo1.sede = sede1;
            _repoPersonalAseo.UpdatePersonalAseo(personalAseo1);
        }
        public static void AddMateria()
        {
            Materia materia;
            materia = new Materia()
            {
                materia = "Desarrollo de Software"
            };
            _repoMateria.AddMateria(materia);
            materia = new Materia()
            {
                materia = "Ingles I"
            };
            _repoMateria.AddMateria(materia);
            materia = new Materia()
            {
                materia = "Coach I"
            };
            _repoMateria.AddMateria(materia);

        }
        public static void UpdateMateria()
        {
            Materia materia;
            Programa programa = _repoPrograma.GetPrograma(3);
            materia = _repoMateria.GetMateria(1);
            materia.programa = programa;
            _repoMateria.UpdateMateria(materia);
            materia = _repoMateria.GetMateria(2);
            materia.programa = programa;
            _repoMateria.UpdateMateria(materia);
            materia = _repoMateria.GetMateria(3);
            materia.programa = programa;
            _repoMateria.UpdateMateria(materia);
        }
    }
}