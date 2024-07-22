# ACME
Este proyecto es una solución para la gestión de cursos y estudiantes en la escuela ACME. La aplicación permite:
Registrar a estudiantes adultos especificando su nombre y edad.
Registrar cursos con nombre, valor de inscripción, fecha de inicio y fecha de fin.
Permitir a un estudiante inscribirse en un curso, previo pago de inscripción a través de una pasarela de pago.
Listar los cursos que han ocurrido entre un rango de fechas y sus estudiantes.
El objetivo del proyecto es proporcionar una solución sencilla y fácil de mantener, preparada para futuras extensiones como la implementación de una API web y la persistencia en una base de datos.

## Estructura del Proyecto
El proyecto está dividido en tres partes:

Dominio: Contiene las clases principales (Curso, Estudiante, Inscripcion) y la interfaz IPago.
Aplicación: Contiene el servicio InscripcionService que maneja la lógica de negocio.
Pruebas Unitarias: Contiene pruebas para verificar el correcto funcionamiento de la aplicación usando xUnit.net y Moq.

## Consideraciones y posibles mejoras
Persistencia de Datos: No se implemento la persistencia de la información en una base de datos. Esto es crucial de incoporar en el futuro ya sea en una base realacional o no.
Integración de Pasarela de Pago Real: Actualmente, IPago es una interfaz simulada. En el futuro, se podría integrar una pasarela de pago real para la validacion de la inscripción.

## Bibliotecas de terceros 
xUnit.net: Utilizado para las pruebas unitarias.
Moq: Utilizado para crear mocks en las pruebas unitarias.

## Tiempo Invertido y Aprendizaje
La resolucion de este test me llevó entre Analisis y diseño, Implementacion de código y pruebas unitarias y Documentación aproxidamente 4 horas.  
En cuánto al aprendizaje si bien ya tenía experiencia con xUnit meter mano a un proyecto de 0 requiera volver a buscar informacion y documentación. 
