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
