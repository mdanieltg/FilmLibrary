# Film Library

Aplicación web para gestionar una colección de información de películas.

## Tecnologías

- .NET 6
- ASP.NET Core
- Microsoft SQL Server

## Ejecución

### Pre-requisitos

- El [SDK de .NET](https://dotnet.microsoft.com/).
- Alguna edición de [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads). Si no está seguro de qué edición elegir, puede ser la Express o la Developer.

### Preparación

Las siguientes instrucciones se deben ejecutar desde una terminal o una _Shell_, como PowerShell o Bash:

1. Instalar la herramienta __dotnet-ef__ con la herramienta `dotnet tool`:
```PowerShell
dotnet tool install --global dotnet-ef
```
2. En el directorio raíz de la solución, restaurar los paquetes NuGet:
```PowerShell
dotnet restore
```
3. Cambiar al directorio FilmLibrary.DataRepository:
```PowerShell
cd FilmLibrary.DataRepository
```
4. Crear la base de datos:
```PowerShell
dotnet ef database update
```

### Ejecución

Finalmente, para ejecutar la aplicación, hay que cambiar al directorio FilmLibrary.WebApp, y luego ejecutar la aplicación con `dotnet run`:
```PowerShell
cd ..
cd FilmLibrary.WebApp
dotnet run
```

¡Todo listo!
