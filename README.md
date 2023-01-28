# WebFormsBlazorCustomElements

En este repositorio se encuentra la implementación de un proyecto de modernización de una aplicación WebForms utilizando Blazor Custom Elements y Yarp.ReverseProxy

## Prerequisitos

- .NET Framework 4.8
- .NET 7
- Visual Studio 2022

## Contexto

Nos encontramos con una aplicación web construida con ASP .NET WebForms que lleva funcionando 10 años. Esta aplicación utiliza una base de datos SQLServer donde para modificar los datos ejecuta directamente StoreProcedures

### El objetivo es realizar una modernización tecnologica de esta aplicación para que sea escalable a nuevas funcionalidades, mantenible a futuro y cuya tecnologia tenga más años de soporte. En este caso, se realizara la modernización a Blazor.

Para realizar esto se utilazan principalmente las siguiente herramientas:
- Blazor Custom Elements
- Yarp.ReverseProxy
- EntityFramework Core 7: Store Procedure Mapping
