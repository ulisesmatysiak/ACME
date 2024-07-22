using ACME.APPLICATION.Services;
using ACME.DOMINIO;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace ACME.TEST
{
    public class InscripcionServiceTest
    {
        [Fact]
        public void Debe_Registrar_Estudiante()
        {
            var servicioPagoMock = new Mock<IPago>();
            var inscripcionService = new InscripcionService(servicioPagoMock.Object);
            var nombreEstudiante = "Ulises Matysiak";
            var edadEstudiante = 24;

            inscripcionService.RegistrarEstudiante(nombreEstudiante, edadEstudiante);

            var estudiantes = inscripcionService.ObtenerEstudiantes().ToList();

            Assert.Single(estudiantes);
            Assert.Equal(nombreEstudiante, estudiantes[0].Nombre);
            Assert.Equal(edadEstudiante, estudiantes[0].Edad);
        }

        [Fact]
        public void Debe_Registrar_Curso()
        {
            var servicioPagoMock = new Mock<IPago>();
            var inscripcionService = new InscripcionService(servicioPagoMock.Object);
            var nombreCurso = "Matemáticas 101";
            var valorCurso = 100m;
            var fechaInicio = new DateTime(2023, 1, 1);
            var fechaFin = new DateTime(2023, 12, 31);

            inscripcionService.RegistrarCurso(nombreCurso, valorCurso, fechaInicio, fechaFin);

            var cursos = inscripcionService.ObtenerCursos().ToList();

            Assert.Single(cursos);
            Assert.Equal(nombreCurso, cursos[0].Nombre);
            Assert.Equal(valorCurso, cursos[0].Valor);
            Assert.Equal(fechaInicio, cursos[0].FechaInicio);
            Assert.Equal(fechaFin, cursos[0].FechaFin);
        }

        [Fact]
        public void Debe_Inscribir_Estudiante_En_Curso_Despues_De_Pago()
        {
            var servicioPagoMock = new Mock<IPago>();
            servicioPagoMock.Setup(p => p.PagoProcesado(It.IsAny<decimal>())).Returns(true);

            var inscripcionService = new InscripcionService(servicioPagoMock.Object);
            var nombreEstudiante = "Ulises Matysiak";
            var edadEstudiante = 24;
            var estudiante = new Estudiante(nombreEstudiante, edadEstudiante);
            var nombreCurso = "Matemáticas 101";
            var valorCurso = 100m;
            var fechaInicio = new DateTime(2023, 1, 1);
            var fechaFin = new DateTime(2023, 12, 31);
            var curso = new Curso(nombreCurso, valorCurso, fechaInicio, fechaFin);

            inscripcionService.Inscribir(estudiante, curso);
            var inscripciones = inscripcionService.ObtenerInscripcionPorFecha(fechaInicio, fechaFin).ToList();

            Assert.Single(inscripciones);
            Assert.Equal(estudiante, inscripciones[0].Estudiante);
            Assert.Equal(curso, inscripciones[0].Curso);        
        }

        [Fact]
        public void No_Debe_Inscribir_Estudiante_Si_Pago_Falla()
        {
            var servicioPagoMock = new Mock<IPago>();
            servicioPagoMock.Setup(p => p.PagoProcesado(It.IsAny<decimal>())).Returns(false);

            var inscripcionService = new InscripcionService(servicioPagoMock.Object);
            var nombreEstudiante = "Ulises Matysiak";
            var edadEstudiante = 24;
            var estudiante = new Estudiante(nombreEstudiante, edadEstudiante);
            var nombreCurso = "Matemáticas 101";
            var valorCurso = 100m;
            var fechaInicio = new DateTime(2023, 1, 1);
            var fechaFin = new DateTime(2023, 12, 31);
            var curso = new Curso(nombreCurso, valorCurso, fechaInicio, fechaFin);

            try
            {
                inscripcionService.Inscribir(estudiante, curso);
                Assert.True(false, "Se esperaba una excepción");
            }
            catch (Exception ex)
            {
                Assert.Equal("El pago falló", ex.Message);
            }
        }

        [Fact]
        public void Debe_Obtener_Inscripciones_Por_Rango_De_Fechas()
        {
            var servicioPagoMock = new Mock<IPago>();
            servicioPagoMock.Setup(p => p.PagoProcesado(It.IsAny<decimal>())).Returns(true);

            var inscripcionService = new InscripcionService(servicioPagoMock.Object);
            var estudiante1 = new Estudiante("Ulises Matysiak", 24);
            var estudiante2 = new Estudiante("Jane Doe", 22);
            var fechaInicio1 = new DateTime(2023, 1, 1);
            var fechaFin1 = new DateTime(2023, 12, 31);
            var fechaInicio2 = new DateTime(2022, 1, 1);
            var fechaFin2 = new DateTime(2022, 12, 31);
            var curso1 = new Curso("Matemáticas 101", 100m, fechaInicio1, fechaFin1);
            var curso2 = new Curso("Ciencias 101", 150m, fechaInicio2, fechaFin2);

            inscripcionService.Inscribir(estudiante1, curso1);
            inscripcionService.Inscribir(estudiante2, curso2);
            var inscripciones = inscripcionService.ObtenerInscripcionPorFecha(new DateTime(2023, 1, 1), new DateTime(2023, 12, 31)).ToList();

            Assert.Single(inscripciones);
            Assert.Equal(estudiante1, inscripciones[0].Estudiante);
            Assert.Equal(curso1, inscripciones[0].Curso);
        }
    }
}