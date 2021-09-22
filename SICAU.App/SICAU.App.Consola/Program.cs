using System;
using System.Collections.Generic;
using System.Linq;
using SICAU.App.Persistencia;
using SICAU.App.Dominio;

namespace SICAU.App.Consola
{
    class Program
    {
        private static IRepositorioPersona _repoPersona = new RepositorioPersona(new Persistencia.AppContext());
        private static IRepositorioPersonalAseo _repoPersonalAseo = new RepositorioPersonalAseo(new Persistencia.AppContext());
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");
            //--------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------
            // Ejecución de Pruebas Clase Persona
            //--------------------------------------------------------------------------------------------
            //AddPersona(); // Testeado Ok
            //FindPersona(1); // Testeado Ok
            //UpdatePersona(1); // Testeado Ok
            //ListarPersona(); // Testeado ok
            //DeletePersona(1); // Testeado Ok
            //--------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------
            // Ejecución de Pruebas Clase PersonalAseo
            //--------------------------------------------------------------------------------------------
            //AddPersonalAseo(); // Testeado Ok
            //FindPersonalAseo(5); // Testeado Ok
            //UpdatePersonalAseo(6); // Testeado Ok
            //ListarPersonalAseo(); // Testeado ok
            //DeletePersonalAseo(5); // Testeado Ok
            //--------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------
            // Ejecución de Pruebas Clase Profesor
            //--------------------------------------------------------------------------------------------
            //AddProfesor(); // Testeado Ok.  Pendiente de creacion cruds Materia para finalizar pruebas
            //FindProfesor(19); // Testeado Ok
            //UpdateProfesor(19); // Testeado Ok. Pendiente de creacion cruds Materia para finalizar pruebas
            //ListarProfesor(); // Testeado Ok
            //DeleteProfesor(17); // Testeado OK

        }
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        // Metodos Clase Persona
        //--------------------------------------------------------------------------------------------
        private static void AddPersona()
        {
            var persona = new Persona
            {
                nombre = "NombrePrueba",
                apellido = "ApellidoPrueba",
                identificacion = "12345678",
                fechaNacimiento = DateTime.Parse("1990-05-12"),
                estadoCovid = EstadoCovid.positivo
            };
            _repoPersona.AddPersona(persona);
        }
        private static void FindPersona(int idPersona)
        {
            var persona = _repoPersona.GetPersona(idPersona);
            Console.WriteLine(persona.nombre + " " + persona.apellido);
        }
        private static void UpdatePersona(int idPersona)
        {
            var persona = _repoPersona.GetPersona(idPersona);
            persona.nombre = "Mario Alejandro";
            persona.apellido = "Zuluaga Ramirez";
            persona.identificacion = "16070445";
            persona.fechaNacimiento = DateTime.Parse("1982-03-01");
            persona.estadoCovid = EstadoCovid.negativo;
            _repoPersona.UpdatePersona(persona);
        }
        private static void ListarPersona()
        {
            IEnumerable<Persona> persona = _repoPersona.GetAllPersona();
            Console.WriteLine(persona.Last().nombre + " " + persona.Last().apellido);
        }
        private static void DeletePersona(int idPersona)
        {
            _repoPersona.DeletePersona(idPersona);
            var persona = _repoPersona.GetPersona(idPersona);
            if (persona == null)
            {
                Console.WriteLine("Registro eliminado");
            }
        }
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        // Metodos Clase Personal Aseo
        //--------------------------------------------------------------------------------------------
        private static void AddPersonalAseo()
        {
            var personalAseo = new PersonalAseo
            {
                nombre = "AseoPrueba",
                apellido = "AseoPrueba",
                identificacion = "12345678",
                fechaNacimiento = DateTime.Parse("1990-05-12"),
                estadoCovid = EstadoCovid.negativo,
                turno = Turno.tarde
            };
            _repoPersonalAseo.AddPersonalAseo(personalAseo);
        }
        private static void FindPersonalAseo(int idPersonalAseo)
        {
            var personalAseo = _repoPersonalAseo.GetPersonalAseo(idPersonalAseo);
            Console.WriteLine(personalAseo.nombre + " " + personalAseo.apellido);
        }
        private static void UpdatePersonalAseo(int idPersonalAseo)
        {
            var personalAseo = _repoPersonalAseo.GetPersonalAseo(idPersonalAseo);
            personalAseo.nombre = "Mario Alejandro";
            personalAseo.apellido = "Zuluaga Ramirez";
            personalAseo.identificacion = "16070445";
            personalAseo.fechaNacimiento = DateTime.Parse("1982-03-01");
            personalAseo.estadoCovid = EstadoCovid.negativo;
            personalAseo.turno = Turno.tarde;
            _repoPersonalAseo.UpdatePersonalAseo(personalAseo);
        }
        private static void ListarPersonalAseo()
        {
            IEnumerable<PersonalAseo> personalAseo = _repoPersonalAseo.GetAllPersonalAseo();
            Console.WriteLine(personalAseo.Last().nombre + " " + personalAseo.Last().apellido);
        }
        private static void DeletePersonalAseo(int idPersonalAseo)
        {
            _repoPersonalAseo.DeletePersonalAseo(idPersonalAseo);
            var personalAseo = _repoPersonalAseo.GetPersonalAseo(idPersonalAseo);
            if (personalAseo == null)
            {
                Console.WriteLine("Registro eliminado");
            }
        }
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        // Metodos Clase Profesor
        //--------------------------------------------------------------------------------------------
        private static void AddProfesor()
        {
            var profesor = new Profesor
            {
                nombre = "NombreProfesor",
                apellido = "ApellidoProfesor",
                identificacion = "12345678",
                fechaNacimiento = DateTime.Parse("1990-05-12"),
                departamento = "Sistemas",
                materia = null
            };
            _repoProfesor.AddProfesor(profesor);
        }

        private static void FindProfesor(int idProfesor)
        {
            var profesor = _repoProfesor.GetProfesor(idProfesor);
            Console.WriteLine(profesor.nombre + " " + profesor.apellido);
        }
        private static void UpdateProfesor(int idProfesor)
        {
            var profesor = _repoProfesor.GetProfesor(idProfesor);
            profesor.nombre = "Mario Alejandro";
            profesor.apellido = "Zuluaga Ramirez";
            profesor.identificacion = "16070445";
            profesor.fechaNacimiento = DateTime.Parse("1982-03-01");
            profesor.departamento = "Ciencias";
            profesor.materia = null;
            _repoProfesor.UpdateProfesor(profesor);
        }
        private static void ListarProfesor()
        {
            IEnumerable<Profesor> profesor = _repoProfesor.GetAllProfesor();
            Console.WriteLine(profesor.Last().nombre + " " + profesor.Last().apellido);
        }
        private static void DeleteProfesor(int idProfesor)
        {
            _repoProfesor.DeleteProfesor(idProfesor);
            var profesor = _repoProfesor.GetProfesor(idProfesor);
            if (profesor == null)
            {
                Console.WriteLine("Registro eliminado");
            }
        }
    }
}
