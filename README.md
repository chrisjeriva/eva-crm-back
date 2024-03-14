# eva-crm-back
Repositorio del código de Back para evaluación técnica

# Importante: 
## Tener instalado previamente `visual studio 2022` 
## .NET 8.0
## paquetes de compatibilidad de `.NET Framework 4.7.2` y `4.8`
## `C#`
## Ejecutar el comando `dotnet tool install --global dotnet-ef` en la terminal de VS
## opcional `ASP.NET MVC4

## Pasos a seguir para tener listo el ambiente para el backend forma `local`
- Abrir la solución
- Limpiar la solución
- Compliar la solución
- Ejecutar los siguientes comandos para la bd
	- `dotnet ef database update` con esto crearemos la BD SQLite en caso de que no exista se generará el archivo `prospectos.db` dentro de la solucion
	de lo contrario, solo se actualizará la bd. 
- Damos Click al boton de Ejecutar o depurar en la barra de Herramientas de debug.

# Base de datos
## Inicialmente se agrega informacion en la tablas `Users`, `Authorities` y `Estatus`

## Usuarios
- user: `admin`       password: `admin` 
- user: `promotor`   password: `promotor00`
- user: `evaluador`   password: `evaluador00`

## Authorities
- `ROLE_ADMIN`
- `ROLE_PROMOTOR`
- `ROLE_EVALUADOR`

## Estatus
- `Enviado`
- `Autorizado`
- `Rechazado`
