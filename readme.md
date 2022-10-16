# Inventory systems

## Introducci�n
Esta soluci�n es una API Rest con arquitectura DDD y patr�n CQRS. La implementaci�n de este patr�n se ha realizado en su forma m�s simple, es decir, se ha desarrollado la estructura para poder tener la separaci�n de los comandos y las consultas pero el repositorio de datos es �nico y tampoco se ha incluido el uso de los eventos.

La soluci�n parte de que existe un sistema de inventario donde hay que implementar la consulta, creaci�n o eliminaci�n de productos. Para llevar a cabo la implementaci�n se ha divido en varios proyectos cada uno con la responsabilidad que le toca.
- Proyecto InventorySystem. Es el proyecto que se encarga del dominio o dominios.
- InventorySystem.Application. Proyecto donde se realiza la implementaci�n de los comandos y las queries.
- InventorySystem.Infrastructure. Proyecto donde se realiza la implementaci�n a los repositorios.
- InventorySystem.API. Proyecto que expone los m�todos para interactuar con el dominio.
- InventorySystem.API.Client. Proyecto que implementa un cliente para poder conectarse con el API de forma sencilla.
- InventorySystem.Test. Proyecto donde se implementa los test unitarios.

## Detalles t�cnicos de la soluci�n.

La soluci�n est� desarrollada en .net 6, por lo que para poder ejecutarla es recomendable tener Visual Studio 2022, no obstante, tambi�n se puede utilizar Visual Studio 2019 pero hay que instalar los paquetes de [.net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

### Paquetes utilizados
- Automapper
- Mediatr
- Microsoft Entity Framework Core (con el paquete para ejecutar una base de datos en memoria)
- Newtonsoft.Json
- StyleCop.Analyzers
- Swagger

### Arquitectura y patrones utilizados.
- Arquitectura DDD
- Patr�n CQRS
- Patr�n repositorio
- Patr�n mediador
- Inyecci�n de dependencias.

### Como probar la soluci�n.

Una vez clonada la soluci�n, abrir visual studio, establecer el proyecto API como inicial y ejecutar la soluci�n. Se abrir� el explorador donde a trav�s de swagger se podr� probar cada uno de los m�todos. Al estar en memoria, cada uno de los art�culos que se introduzca se quedar� reflejado hasta que se finalice la ejecuci�n.
