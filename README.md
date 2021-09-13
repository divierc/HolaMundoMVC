# HolaMundoMVC
Programa para revisar MVC con .NetCore

https://docs.microsoft.com/en-us/ef/core/get-started/overview/install

Install-Package Microsoft.EntityFrameworkCore.Tools
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet restore

dotnet aspnet-codegenerator controller -name AlumnoController -m Alumno -dc EscuelaContext --relativefolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f