# MinTic_2022_LosPrimeros5
Proyecto MinTic Ciclo 3. Desarrollo de Software

## Tipos de proyectos
1. Aplicacion = sln (Agrupa conjunto de proyectos)
2. Presentación = csproject - razor
3. Dominio = csproject - classlib
4. Persistencia = csproject - classlib
5. Servicios = csproject - webapi

## Creacion de proyectos (CMD):
1. Crear carpeta de programa
2. Ingresar a la carpeta de programa 
3. Crear sln = dotnet new sln -o NameDir.App
4. Crear Presentación = dotnet new console -o NameDir.App.Consola
5. Crear Persistencia = dotnet new classlib -o NameDir.App.Persistencia
6. Crear Dominio = dotnet new classlib -o NameDir.App.Dominio
7. Crear Servicios = dotnet new webapi -o NameDir.App.Servicios

## Capa Dominio. (Anotación Pascal)
1. Clases
public class NameClass
{
	public DataType NameAtrrib {get;set;}
}
2. Herencia 
	Al final de la clase ":" nombre clase a heredar
3. Asociacion
En la clase a crear se realiza la asociación: public NameClass NameAsociacion {get;set;}

## Implementación Capa Dominio. Clases (Visual Studio Code)
1. En la capa de Dominio. Crear carpeta de "Entidades"
2. En carpeta de Entidades crear archivo por cada clase NameClass.cs
3. Para atributos con erorr, generar clases o tipos propios ("enum" separados por ",")

## Instalación de paquetes
### Global
1. dotnet tool install --global dotnet-ef
2. dotnet tool update --global dotnet-ef
### Proyecto
1. dotnet add package Microsoft.EntityFrameworkCore --Version 5.0.0
2. dotnet add package Microsoft.EntityFrameworkCore.Tools --Version 5.0.0
3. dotnet add package Microsoft.EntityFrameworkCore.Desing --Version 5.0.0
4. dotnet add package Microsoft.EntityFrameworkCore.SqlServer --Version 5.0.0

## Implementación de Capa de Persistencia (Visual Studio Code)
1. Ingresar a la capa de persistencia
2. Instalar paquetes de proyecto (En error cambiar el netstandar)
3. Crear carpeta AppData
4. Crear carpeta AppRepositorios
5. Ingresar a AppRepositorios
6. Crear clase AppContext.cs
using Microsoft.EntityFrameworkCore;
using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Persistencia
{
	public class AppContext:DbContext
	{
		public DbSet<Persona> Personas {get;set;}
			protectes override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)	
	}
		optionsBuilder
		.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HospiEnCasaData");
	}
}
8. Agregar referencia: dotnet add referencia ..\HospiEnCasa.App.Dominio\
9. Compilar = dotnet build
10. Cambiar a carpeta consola
11. Instalar paquete = dotnet add package Microsoft.EntityFrameworkCore.Desing --Version 5.0.0
12. Agregar referencia = dotnet add reference ..\HospiEnCasa.App.Persistencia
13. En Program.cs ingresar la referencia = using HospiEnCasa.App.Dominio;
14. Guardar y compilar
15. Cambiar a Capa Persistencia
16. Migración = dotnet ef migrations add Inicial --startup-project ..\HospiEnCasa.App.Console\
17. Actualizar BD = dotnet ef database update --starup-project ..\HospiEnCasa.App.Console\
