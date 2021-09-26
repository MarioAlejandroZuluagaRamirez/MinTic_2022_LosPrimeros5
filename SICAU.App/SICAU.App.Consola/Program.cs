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
        private static IRepositorioSede _repoSede = new RepositorioSede(new Persistencia.AppContext());
        private static IRepositorioSalon _repoSalon = new RepositorioSalon(new Persistencia.AppContext());
        private static IRepositorioEstudiante _repoEstudiante = new RepositorioEstudiante(new Persistencia.AppContext());
        private static IRepositorioDirectivo _repoDirectivo = new RepositorioDirectivo(new Persistencia.AppContext());
        private static IRepositorioMateria _repoMateria = new RepositorioMateria (new Persistencia.AppContext());
        private static IRepositorioHorario _repoHorario = new RepositorioHorario (new Persistencia.AppContext());
        private static IRepositorioEncuesta _repoEncuesta = new RepositorioEncuesta(new Persistencia.AppContext());
        private static IRepositorioSintoma _repoSintoma = new RepositorioSintoma(new Persistencia.AppContext());

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
            //ListPersona(); // Testeado ok
            //DeletePersona(1); // Testeado Ok
            //--------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------
            // Ejecución de Pruebas Clase PersonalAseo
            //--------------------------------------------------------------------------------------------
            //AddPersonalAseo(); // Testeado Ok
            //FindPersonalAseo(5); // Testeado Ok
            //UpdatePersonalAseo(6); // Testeado Ok
            //ListPersonalAseo(); // Testeado ok
            //DeletePersonalAseo(5); // Testeado Ok
            //--------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------
            // Ejecución de Pruebas Clase Profesor
            //--------------------------------------------------------------------------------------------
            //AddProfesor(); // Testeado Ok.  Pendiente de creacion cruds Materia para finalizar pruebas
            //FindProfesor(19); // Testeado Ok
            //UpdateProfesor(19); // Testeado Ok. Pendiente de creacion cruds Materia para finalizar pruebas
            //ListProfesor(); // Testeado Ok
            //DeleteProfesor(17); // Testeado OK
            //--------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------
            // Ejecución de Pruebas Clase Sede
            //--------------------------------------------------------------------------------------------
            // AddSede();       // Testeado Ok
            // FindSede(1);     // Testeado Ok
            // UpdateSede(1);   // Testeado Ok
            // ListSede();      // Testeado Ok
            // DeleteSede(2);   // Testeado Ok
            //--------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------
            // Ejecución de Pruebas Clase Salon
            //--------------------------------------------------------------------------------------------
            // AddSalon();      // Testeado Ok
            // FindSalon(1);    // Testeado Ok
            // UpdateSalon(1);  // Testeado Ok
            // ListSalon();     // Testeado Ok
            // DeleteSalon(2);  // Testeado Ok
            //--------------------------------------------------------------------------------------------
            // Ejecución de Pruebas Clase Estudiante
            //--------------------------------------------------------------------------------------------
            // AddEstudiante();      // Testeado Ok
            // FindEstudiante(1);    // Testeado Ok
            // UpdateEstudiante(1);  // Testeado Ok
            // ListEstudiante();     // Testeado Ok
            // DeleteEstudiante(3);  // Testeado Ok
            //--------------------------------------------------------------------------------------------
            // Ejecución de Pruebas Clase Directivo
            //--------------------------------------------------------------------------------------------
            // AddDirectivo();      // Testeado Ok
            // FindDirectivo(4);    // Testeado Ok
            // UpdateDirectivo(4);  // Testeado Ok
            // ListDirectivo();     // Testeado Ok
            // DeleteDirectivo(5);  // Testeado Ok

            //--------------------------------------------------------------------------------------------
            // Ejecución de Pruebas Clase Materia
            //--------------------------------------------------------------------------------------------
            // AddMateria();      // Testeado Ok
            // FindMateria(1);    // Testeado Ok
            // UpdateMateria(1);  // Testeado Ok
            // ListMateria();     // Testeado Ok
            // DeleteMateria(4);  // Testeado Ok
            //--------------------------------------------------------------------------------------------
            // Ejecución de Pruebas Clase Hoario
            //--------------------------------------------------------------------------------------------
            // AddHorario();      // Testeado Ok
            // FindHorario(1);    // Testeado Ok
            // UpdateHorario(1);  // Testeado Ok
            // ListHorario();     // Testeado Ok
            // DeleteHorario(2);  // Testeado Ok
            //--------------------------------------------------------------------------------------------
            // Ejecución de Pruebas Clase Encuesta
            //--------------------------------------------------------------------------------------------
            // AddEncuesta();      // Testeado Ok
            // FindEncuesta(1);    // Testeado Ok
            // UpdateEncuesta(1);  // Testeado Ok
            // ListEncuesta();     // Testeado Ok
            // DeleteEncuesta(1);  // Testeado Ok
            //--------------------------------------------------------------------------------------------
            // Ejecución de Pruebas Clase Sintomas
            //--------------------------------------------------------------------------------------------
            // AddSintoma();      // Testeado Ok
            // FindSintoma(1);    // Testeado Ok
            // UpdateSintoma(1);  // Testeado Ok
            // ListSintoma();     // Testeado Ok
            //DeleteSintoma(2);  // Testeado Ok
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
        private static void ListPersona()
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
        private static void ListPersonalAseo()
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
        private static void ListProfesor()
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
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        // Metodos Clase Sede
        //--------------------------------------------------------------------------------------------

        private static void AddSede()
        {
            var sede = new Sede
            {
                nombre = "NombreSede",
                descripcion = "Esta es la sede principal",
                ubicacion = "Medellin Antioquia calle 26 # 35 - 14 barrio las palmas",
               
            };
            _repoSede.AddSede(sede);
        }
        private static void FindSede(int idSede)
        {
            var sede = _repoSede.GetSede(idSede);
            Console.WriteLine(sede.nombre + " " + sede.descripcion + " " + sede.ubicacion);
        }
        private static void UpdateSede(int idSede)
        {
            var sede = _repoSede.GetSede(idSede);
            sede.nombre = "Sede Principal";
            sede.descripcion = "Sede Principal De Ingenieria";
            sede.ubicacion = "Medellin Antioquia calle 26 # 35 - 14 barrio las palmas";
            
            _repoSede.UpdateSede(sede);
        }
        private static void ListSede()
        {
            IEnumerable<Sede> sede = _repoSede.GetAllSede();
            Console.WriteLine(sede.Last().nombre + " " + sede.Last().descripcion + " " + sede.Last().ubicacion);
        }
        private static void DeleteSede(int idSede)
        {
            _repoSede.DeleteSede(idSede);
            var sede = _repoSede.GetSede(idSede);
            if (sede == null)
            {
                Console.WriteLine("Registro eliminado");
            }
        }
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        // Metodos Clase Salon
        //--------------------------------------------------------------------------------------------

        private static void AddSalon()
        {
            var salon = new Salon
            {
                numero = "310",
                capacidad = "50",
                
               
            };
            _repoSalon.AddSalon(salon);
        }
        private static void FindSalon(int idSalon)
        {
            var salon = _repoSalon.GetSalon(idSalon);
            Console.WriteLine(salon.numero + " " + salon.capacidad);
        }
        private static void UpdateSalon(int idSalon)
        {
            var salon = _repoSalon.GetSalon(idSalon);
            salon.numero = "311";
            salon.capacidad = "40";
                        
            _repoSalon.UpdateSalon(salon);
        }
        private static void ListSalon()
        {
            IEnumerable<Salon> salon = _repoSalon.GetAllSalon();
            Console.WriteLine(salon.Last().numero + " " + salon.Last().capacidad);
        }
        private static void DeleteSalon(int idSalon)
        {
            _repoSalon.DeleteSalon(idSalon);
            var salon = _repoSalon.GetSalon(idSalon);
            if (salon == null)
            {
                Console.WriteLine("Registro eliminado");
            }
        }
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        // Metodos Clase Estudiante
        //--------------------------------------------------------------------------------------------
         private static void AddEstudiante()
        {
            var estudiante = new Estudiante
            {
                nombre = "NombreEstudiante",
                apellido = "ApellidoEstudiante",
                identificacion = "9876321",
                fechaNacimiento = DateTime.Parse("1999-01-16"),
                semestre = 2,
                carrera = "Ingeniería"                
            };
            _repoEstudiante.AddEstudiante(estudiante);
        }

        private static void FindEstudiante(int idEstudiante)
        {
            var estudiante = _repoEstudiante.GetEstudiante(idEstudiante);
            Console.WriteLine(estudiante.nombre + " " + estudiante.apellido);
        }
        private static void UpdateEstudiante(int idEstudiante)
        {
            var estudiante = _repoEstudiante.GetEstudiante(idEstudiante);
            estudiante.nombre = "Roberto";
            estudiante.apellido = "Martinez Mejia";
            estudiante.identificacion = "19992121";
            estudiante.fechaNacimiento = DateTime.Parse("1980-12-31");
            estudiante.semestre = 2;
            estudiante.carrera = "Ingenieria de Sistemas";
            _repoEstudiante.UpdateEstudiante(estudiante);
        }
        private static void ListEstudiante()
        {
            IEnumerable<Estudiante> estudiante = _repoEstudiante.GetAllEstudiante();
            Console.WriteLine(estudiante.Last().nombre + " " + estudiante.Last().apellido);
        }
        private static void DeleteEstudiante(int idEstudiante)
        {
            _repoEstudiante.DeleteEstudiante(idEstudiante);
            var estudiante = _repoEstudiante.GetEstudiante(idEstudiante);
        }
        // Metodos Clase Materia
        //--------------------------------------------------------------------------------------------
        private static void AddMateria()
        {
            var materia = new Materia
            {
                materia = "MateriaPrueba",
            };
            _repoMateria.AddMateria(materia);
        }
        private static void FindMateria (int idMateria)
        {
            var materia = _repoMateria.GetMateria(idMateria);
            Console.WriteLine(materia.materia);
        }
        private static void UpdateMateria(int idMateria)
        {
            var materia = _repoMateria.GetMateria(idMateria);
            materia.materia = "Desarrollo de software";
            _repoMateria.UpdateMateria(materia);
        }
        private static void ListMateria()
        {
            IEnumerable<Materia> materia = _repoMateria.GetAllMateria();
            Console.WriteLine(materia.Last().materia);
        }
        private static void DeleteMateria(int idMateria)
        {
            _repoMateria.DeleteMateria(idMateria);
            var materia = _repoMateria.GetMateria(idMateria);
            if (materia == null)
            {
                Console.WriteLine("Registro eliminado");
            }
        }

        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        // Metodos Clase Directivo
        //--------------------------------------------------------------------------------------------
         private static void AddDirectivo()
        {
            var directivo = new Directivo
            {
                nombre = "NombreDirectivo",
                apellido = "ApellidoDirectivo",
                identificacion = "6321",
                fechaNacimiento = DateTime.Parse("2000-01-16"),
                unidad = "Rectoría"
            };
            _repoDirectivo.AddDirectivo(directivo);
        }

        private static void FindDirectivo(int idDirectivo)
        {
            var directivo = _repoDirectivo.GetDirectivo(idDirectivo);
            Console.WriteLine(directivo.nombre + " " + directivo.apellido);
        }
        private static void UpdateDirectivo(int idDirectivo)
        {
            var directivo = _repoDirectivo.GetDirectivo(idDirectivo);
            directivo.nombre = "Roberto";
            directivo.apellido = "Martinez Mejia";
            directivo.identificacion = "454545";
            directivo.fechaNacimiento = DateTime.Parse("1980-12-31");            
            directivo.unidad = "Recursos Humanos";
            _repoDirectivo.UpdateDirectivo(directivo);
        }
        private static void ListDirectivo()
        {
            IEnumerable<Directivo> directivo = _repoDirectivo.GetAllDirectivo();
            Console.WriteLine(directivo.Last().nombre + " " + directivo.Last().apellido);
        }
        private static void DeleteDirectivo(int idDirectivo)
        {
            _repoDirectivo.DeleteDirectivo(idDirectivo);
            var directivo = _repoDirectivo.GetDirectivo(idDirectivo);
        }
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        // Metodos Clase Hoario
        //--------------------------------------------------------------------------------------------
        private static void AddHorario()
        {
            var horario = new Horario
            {
                horaIngreso = DateTime.Parse ("01/01/1900 18:00:00"),
                materia = null,
                diasemana = DiaSemana.lunes,
                duracion = 120,
                persona = null,
                salon = null
            };
            _repoHorario.AddHorario(horario);
        }
        private static void FindHorario (int idHorario)
        {
            var horario = _repoHorario.GetHorario(idHorario);
            Console.WriteLine(horario.horaIngreso);
        }
        private static void UpdateHorario(int idHorario)
        {
            var persona = _repoPersona.GetPersona(18);
            var materia = _repoMateria.GetMateria(1);
            var horario = _repoHorario.GetHorario(idHorario);
            horario.horaIngreso = DateTime.Parse("20:00:00");
            horario.materia = materia;
            horario.persona = persona;
            horario.salon = null;
            _repoHorario.UpdateHorario(horario);
        }
        private static void ListHorario()
        {
            IEnumerable<Horario> horario = _repoHorario.GetAllHorario();
            Console.WriteLine(horario.Last().horaIngreso);
        }
        private static void DeleteHorario(int idHorario)
        {
            _repoHorario.DeleteHorario(idHorario);
            var horario = _repoHorario.GetHorario(idHorario);
            if (horario == null)
            {
                Console.WriteLine("Registro eliminado");
            }
        }
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        // Metodos Clase Encuesta
        //--------------------------------------------------------------------------------------------
        private static void AddEncuesta()
        {
            var encuesta = new Encuesta
            {
                //id = 1010,
                fechaEncuesta = DateTime.Parse("2021-09-25"),
                estadoCovid = EstadoCovid.positivo,
                sintoma = null,
                fechaDiagnostico = DateTime.Parse("2021-09-24"),
                persona = null,            
               
            };
            _repoEncuesta.AddEncuesta(encuesta);
        }
        private static void FindEncuesta(int idEncuesta)
        {
            var encuesta = _repoEncuesta.GetEncuesta(idEncuesta);
            Console.WriteLine(encuesta.id + " " + encuesta.fechaEncuesta + " " + encuesta.estadoCovid
            + " " + encuesta.sintoma + " " + encuesta.fechaDiagnostico + " " + encuesta.persona);
        }
        private static void UpdateEncuesta(int idEncuesta)
        {
            var encuesta = _repoEncuesta.GetEncuesta(idEncuesta);
            encuesta.fechaEncuesta = DateTime.Parse("2020-08-23");
            encuesta.estadoCovid = EstadoCovid.negativo;
            encuesta.sintoma = null;
            encuesta.fechaDiagnostico = DateTime.Parse("2020-08-22");
            encuesta.persona= null;
                        
            _repoEncuesta.UpdateEncuesta(encuesta);
        }
        private static void ListEncuesta()
        {
            IEnumerable<Encuesta> encuesta = _repoEncuesta.GetAllEncuesta();
            Console.WriteLine(encuesta.Last().id + " " + encuesta.Last().fechaEncuesta + " " + encuesta.Last().estadoCovid
            + " " + encuesta.Last().sintoma + " " + encuesta.Last().fechaDiagnostico + " " + encuesta.Last().persona);
        }
        private static void DeleteEncuesta(int idEncuesta)
        {
            _repoEncuesta.DeleteEncuesta(idEncuesta);
            var encuesta = _repoEncuesta.GetEncuesta(idEncuesta);
            if (encuesta == null)
            {
                Console.WriteLine("Registro eliminado");
            }
        }
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        // Metodos Clase Sintomas
        //--------------------------------------------------------------------------------------------
        private static void AddSintoma()
        {
            var sintoma = new Sintoma
            {                
                sintoma = "Perdida del gusto"
            };
            _repoSintoma.AddSintoma(sintoma);
        }
        private static void FindSintoma(int idSintoma)
        {
            var sintoma = _repoSintoma.GetSintoma(idSintoma);
            Console.WriteLine(sintoma.id + " " + sintoma.sintoma);
        }
        private static void UpdateSintoma(int idSintoma)
        {
            var sintoma = _repoSintoma.GetSintoma(idSintoma);
            sintoma.sintoma = "Tos";
                        
            _repoSintoma.UpdateSintoma(sintoma);
        }
        private static void ListSintoma()
        {
            IEnumerable<Sintoma> sintoma = _repoSintoma.GetAllSintoma();
            Console.WriteLine(sintoma.Last().id + " " + sintoma.Last().sintoma);
        }
        private static void DeleteSintoma(int idSintoma)
        {
            _repoSintoma.DeleteSintoma(idSintoma);
            var sintoma = _repoSintoma.GetSintoma(idSintoma);
            if (sintoma == null)
            {
                Console.WriteLine("Registro eliminado");
            }
        }
    }
}