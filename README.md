# MinTic_2022_LosPrimeros5
Proyecto MinTic Ciclo 3. Desarrollo de Software

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

## Capa Dominio. (Anotación Pascal)
1. Clases
`public class NameClass
{
	public DataType NameAtrrib {get;set;}
}`
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
1. `dotnet add package Microsoft.EntityFrameworkCore --Version 5.0.0`
2. `dotnet add package Microsoft.EntityFrameworkCore.Tools --Version 5.0.0`
3. `dotnet add package Microsoft.EntityFrameworkCore.Desing --Version 5.0.0`
4. `dotnet add package Microsoft.EntityFrameworkCore.SqlServer --Version 5.0.0`

## Implementación de Capa de Persistencia (Visual Studio Code)
1. Ingresar a la capa de persistencia
2. Instalar paquetes de proyecto (En error cambiar el netstandar)
3. Crear carpeta AppData
4. Crear carpeta AppRepositorios
5. Ingresar a AppRepositorios
6. Crear clase AppContext.cs
`using Microsoft.EntityFrameworkCore;
using NameProject.App.Dominio;
namespace NameProject.App.Persistencia
{
	public class AppContext:DbContext
	{
		public DbSet<"Entidad"> Personas {get;set;}
			protectes override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)	
	}
		optionsBuilder
		.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = NameProjectData");
	}
}`
8. Agregar referencia: `dotnet add referencia ..\NameProject.App.Dominio\`
9. Compilar = `dotnet build`
10. Cambiar a carpeta consola
11. Instalar paquete = `dotnet add package Microsoft.EntityFrameworkCore.Desing --Version 5.0.0`
12. Agregar referencia = `dotnet add reference ..\NameProject.App.Persistencia`
13. En Program.cs ingresar la referencia = `using NameProject.App.Dominio;`
14. Guardar y compilar
15. Cambiar a Capa Persistencia
16. Migración = `dotnet ef migrations add Inicial --startup-project ..\NameProject.App.Console\`
17. Actualizar BD = `dotnet ef database update --starup-project ..\NameProject.App.Console\`
