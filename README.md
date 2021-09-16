# MinTic_2022_LosPrimeros5. 
Proyecto MinTic Ciclo 3. Desarrollo de Software

### GitHub
git init
git remote add origin URLRepository

## Aplicaciones
1. .NET Core
2. SQLServer
3. Visual Studio Code
4. SQL Managmente

## Tipos de proyectos
1. Aplicacion = sln (Agrupa conjunto de proyectos)
2. Presentación = csproject - razor
3. Dominio = csproject - classlib
4. Persistencia = csproject - classlib
5. Servicios = csproject - webapi

## Creacion de proyectos (CMD):
1. Crear carpeta de Proyecto
2. Ingresar a la carpeta de Proyecto 
3. Crear sln = `dotnet new sln -o NameProject.App`
4. Crear Presentación = `dotnet new console -o NameProject.App.Consola`
5. Crear Persistencia = `dotnet new classlib -o NameProject.App.Persistencia`
6. Crear Dominio = `dotnet new classlib -o NameProject.App.Dominio`
7. Crear Servicios = `dotnet new webapi -o NameProject.App.Servicios`

## Capa Dominio. (Anotación camelCase)
1. Clases

		using System;
		namespace NameProject.App.Dominio
		{
			public class NameClass
			{
				public DataType NameAtrrib {get;set;}
			}
		}
2. Herencia 
	Al final de la clase ":" nombre clase a heredar
3. Asociacion
En la clase a crear se realiza la asociación: `public NameClass NameAsociacion {get;set;}`

## Implementación Capa Dominio. Clases (Visual Studio Code)
1. En la capa de Dominio. Crear carpeta de "Entidades"
2. En carpeta de Entidades crear archivo por cada clase NameClass.cs
3. Para atributos con error, generar clases o tipos propios ("enum" separados por ",")

## Instalación de paquetes
### Global
1. `dotnet tool install --global dotnet-ef`
2. `dotnet tool update --global dotnet-ef`
### Proyecto
1. `dotnet add package Microsoft.EntityFrameworkCore --version 5.0.0`
2. `dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.0`
3. `dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.0`
4. `dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.0`

## Implementación de Capa de Persistencia (Visual Studio Code)
1. Ingresar a la capa de persistencia
2. Instalar paquetes de proyecto (En error cambiar el netstandar)
3. Crear carpeta AppData
4. Crear carpeta AppRepositorios
5. Ingresar a AppRepositorios
6. Crear clase AppContext.cs

		using Microsoft.EntityFrameworkCore;
		using NameProject.App.Dominio;
		namespace NameProject.App.Persistencia
		{
		    public class AppContext : DbContext
		    {
			    public DbSet<Entity> Atribute {get;set;} 
			    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			{
			    if (!optionsBuilder.IsConfigured)
			    {
				optionsBuilder
				.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = NameProjectData");
			    }
			}
		    }
		}
7. Agregar referencia: `dotnet add reference ..\NameProject.App.Dominio\`
8. Compilar = `dotnet build`
9. Cambiar a carpeta consola
10. Instalar paquete = `dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.0`
11. Agregar referencia = `dotnet add reference ..\NameProject.App.Persistencia`
12. Agregar referencia = `dotnet add reference ..\NameProject.App.Dominio`
13. En Program.cs ingresar la referencia = `using NameProject.App.Dominio;` y `using NameProject.App.Persistencia;`
14. Guardar y compilar
15. Cambiar a Capa Persistencia
16. Migración = `dotnet ef migrations add NameMigrations --startup-project ..\NameProject.App.Console\`
17. Actualizar BD = `dotnet ef database update --startup-project ..\NameProject.App.Console\`

## Eliminar Migración
1. Actualizar DB = `dotnet ef database update --startup-project ..\NameProject.App.Console\`
2. Revertir Migración = `dotnet ef database update 0 --startup-project ..\NameProject.App.Console\`
3. Eliminar Migración = `dotnet ef migrations remove --startup-project ..\NameProject.App.Console\`

## Implementación de Metodos para manipulación de BD
En carpeta Persistencia\AppRepositorios
1. Crear archivo IRepositorioEntidad.cs
2. Codigo = 

		using System.Collections.Generic;
		using NameProject.App.Dominio;

		namespace NameProject.App.Persistencia
		{
			public interface IRepositorioEntidad
			{
				//Metodos
				IEnumerable<Entidad> GetAllEntidad();
				//DataType Nombre_Metodo (DataType NameVariable)
				Entidad AddEntidad(Entidad NameVariable);
				Entidad UpdateEntidad(Entidad NameVariable);
				void DeleteEntidad (int idEntidad);
				Entidad GetEntidad (int idEntidad);
			}
		}
3. Crear archivo RepositorioEntidad.cs
4. Codigo =

		using System.Collections.Generic;
		
		using NameProject.App.Dominio;
		
		using System.Linq;

		namespace NameProject.App.Persistencia
		{
			public class RepositorioEntidad:IRepositorioEntidad
			{
				private readonly AppContext _appContext;

				public RepositorioEntidad(AppContext appContext)
				{
				    _appContext = appContext;
				}

				//Implementar metodos de la clase Super
				Entidad IRepositorioEntidad.AddEntidad(Entidad NameVariable)
				{
					var entidadAdicionado = _appContext.Entidad.Add(NameVariable);
					_appContext.SaveChanges();
					return entidadAdicionado.Entity;
				}

				void IRepositorioEntidad.DeleteEntidad(int idEntidad)
				{
					var entidadEncontrado = _appContext.Entidad.FirstOrDefault(p => p.id == idEntidad);
					if (entidadEncontrado == null) 
						return;
					_appContext.Entidad.Remove (entidadEncontrado);
					_appContext.SaveChanges();
				}

				IEnumerable<Entidad> IRepositorioEntidad.GetAllEntidad ()
				{
					return _appContext.Entidad;
				}

				Entidad IRepositorioEntidad.GetEntidad (int idEntidad)
				{
					return _appContext.Entidad.FirstOrDefault(p => p.id == idEntidad);
				}

				Entidad IRepositorioEntidad.UpdateEntidad (Entidad NameVariable)
				{
					var entidadEncontrado = _appContext.Entidad.FirstOrDefault(p => p.id == entidad.id);
					if (entidadEncontrado !=null)
					{
						entidadEncontrado.Atributo1 = Entidad.Atributo1
						entidadEncontrado.Atributo2 = Entidad.Atributo2
						...
						entidadEncontrado.Atributon = Entidad.Atributon
						_appContext.SaveChanges();
					}
					return entidadEncontrado;
				}

			}
		}
5. Compilar
6. Validar: Creación de consola, add references (Persistencia / Dominio) y using (Persistencia / Dominio).
7. En consola adicionar Repositorio y Metodo
	
		private static IRepositorioEntidad _repoEntidad = new RepositorioEntidad(new Persistencia.AppContext());

		private static void AddEntidad ()
		{
			var NameVariable = new Entidad
			{
				Atributo1 = "",
				Atributo2 = "",
				....
				AtributoN = ""
			};
			_repoEntidad.AddEntidad(NameVariable);
		}

		private static void FindEntidad (int idEntidad)
		{
			var NameVariable = _repoEntidad.GetEntidad(idEntidad);
			Console.WriteLine(Entidad.Atributo1 );
		}
		
		private static void UpdateEntidad(int idEntidad)
		{
		    var NameVariable = _repoEntidad.GetEntidad(idEntidad);
		    Namevariable.Atributo1 = "XXX";
		    Namevariable.Atributo2 = "XX";
		    _repoEntidad.UpdateEntidad(NameVariable);
		}
		
		private static void DeleteEntidad(int idEntidad)
		{
		    _repoEntidad.DeleteEntidad(idEntidad);
		    var NameVariable = _repoEntidad.GetEntidad(idEntidad);
		    if (NameVariable == null)
		    {
			Console.WriteLine("Registro eliminado");
		    }
		}

		private static void ListarEntidad()
		{
		    IEnumerable<Entidad> NameVariable = _repoEntidad.GetAllEntidad();
		    Console.WriteLine(NameVariable.First().Atributo);
		}
	
8. En el main llamar al metodo creado en el punto anterior.
9. Ejectura proyecto: `dotnet run`
