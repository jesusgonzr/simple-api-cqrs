# Inventory systems

## Introducción
Esta solución es una API Rest con arquitectura DDD y patrón CQRS. La implementación de este patrón se ha realizado en su forma más simple, es decir, se ha desarrollado la estructura para poder tener la separación de los comandos y las consultas pero el repositorio de datos es único y tampoco se ha incluido el uso de los eventos.

La solución parte de que existe un sistema de inventario donde hay que implementar la consulta, creación o eliminación de productos. Para llevar a cabo la implementación se ha divido en varios proyectos cada uno con la responsabilidad que le toca.
- Proyecto InventorySystem. Es el proyecto que se encarga del dominio o dominios.
- InventorySystem.Application. Proyecto donde se realiza la implementación de los comandos y las queries.
- InventorySystem.Infrastructure. Proyecto donde se realiza la implementación a los repositorios.
- InventorySystem.API. Proyecto que expone los métodos para interactuar con el dominio.
- InventorySystem.API.Client. Proyecto que implementa un cliente para poder conectarse con el API de forma sencilla.
- InventorySystem.Test. Proyecto donde se implementa los test unitarios.

## Detalles técnicos de la solución.

La solución está desarrollada en .net 6, por lo que para poder ejecutarla es recomendable tener Visual Studio 2022, no obstante, también se puede utilizar Visual Studio 2019 pero hay que instalar los paquetes de [.net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

### Paquetes utilizados
- Automapper
- Mediatr
- Microsoft Entity Framework Core (con el paquete para ejecutar una base de datos en memoria)
- Newtonsoft.Json
- StyleCop.Analyzers
- Swagger

### Arquitectura y patrones utilizados.
- Arquitectura DDD
- Patrón CQRS
- Patrón repositorio
- Patrón mediador
- Inyección de dependencias.

### Como probar la solución.

Una vez clonada la solución, abrir visual studio, establecer el proyecto API como inicial y ejecutar la solución. Se abrirá el explorador donde a través de swagger se podrá probar cada uno de los métodos. Al estar en memoria, cada uno de los artículos que se introduzca se quedará reflejado hasta que se finalice la ejecución.
