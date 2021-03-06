# Ordos
Ordos: Comtrade Manager para cumplimiento del Sistema de Lectura Remota de Protecciones del Coordinador Eléctrico Nacional de Chile.

# Dependencias
Este proyecto utiliza las siguientes dependencias: 
- [.Net Core](https://github.com/dotnet/core)
- [ASP.NET Entity Framework Core](https://github.com/aspnet/EntityFrameworkCore)
- [libiec61850](https://github.com/mz-automation/libiec61850)
- [Fluent Scheduler](https://github.com/fluentscheduler/FluentScheduler)
- [PostgreSQL](https://github.com/postgres/postgres)
- [NLog](https://github.com/NLog/NLog)
- [xUnit](https://github.com/xunit/xunit)

Todas estas dependencias se resuelven automáticamente por NuGet. (`dotnet restore`)

# Licenciamiento
Este proyecto está bajo la licencia [GNU General Public License Version 3](https://github.com/gabrieldelaparra/Ordos/blob/master/LICENSE.MD)

Las dependencias ocupadas tienen las siguientes licencias:
- [.Net Core](https://github.com/dotnet/core/blob/master/LICENSE.TXT): MIT License
- [ASP.NET Entity Framework Core](https://github.com/aspnet/EntityFrameworkCore/blob/master/LICENSE.txt): Apache License 2.0
- [libiec61850](https://github.com/mz-automation/libiec61850/blob/v1.3/COPYING): GNU General Public License Version 3
- [Fluent Scheduler](https://github.com/fluentscheduler/FluentScheduler/blob/master/LICENSE): BSD 3-Clause "New" or "Revised" License
- [PostgreSQL](https://github.com/postgres/postgres/blob/master/COPYRIGHT): PostgreSQL License
- [NLog](https://github.com/NLog/NLog/blob/dev/LICENSE.txt): BSD 3-Clause "New" or "Revised" License
- [xUnit](https://github.com/xunit/xunit/blob/master/license.txt): Apache License 2.0


# Contribuciones o dudas
Cualquier duda o comentario, pueden [crear un Issue](https://help.github.com/articles/creating-an-issue/).

# Instalación: Docker
### Requisitos:
- git
- Docker

### Clonar el repositorio
```
git clone https://github.com/gabrieldelaparra/Ordos.git
cd Ordos
```
### Correr los tests (Opcional, pero recomendado)
```
docker-compose -f "docker-compose.test.yml" up --build
```
### Ejecutar la aplicación
```
docker-compose -f "docker-compose.yml" up -d --build
```

# Instalación: Source

### Requisitos
- Descargar e instalar [.Net Core](https://www.microsoft.com/net/download) (x64).
- Descargar e Instalar [PostgreSQL](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads) (x64)
> La contraseña que se coloque, debe setearse en el `launchsettings.json`.

### Clonar el repositorio
```
git clone https://github.com/gabrieldelaparra/Ordos.git
cd Ordos
```
### Build
```
dotnet build
```
### Correr los tests (Opcional, pero recomendado)
```
dotnet test Ordos.Tests
```
###  Ejecutar la aplicación 
#### Windows
```
dotnet run -p Ordos.Server --launch-profile WindowsDev
```
#### Linux
```
dotnet run -p Ordos.Server --launch-profile LinuxDev
```
Luego, setear el nombre de la compañía y agregar los IEDs.
> Las oscilografías se extraen a la carpeta `./Ordos/` con los archivos estructurados según los requerimientos del SLRP.
