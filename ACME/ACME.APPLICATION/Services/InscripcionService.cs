using ACME.DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.APPLICATION.Services
{
    public class InscripcionService
    {
        private readonly List<Inscripcion> _inscripcion = new List<Inscripcion>();
        private readonly List<Estudiante> _estudiantes = new List<Estudiante>();
        private readonly List<Curso> _cursos = new List<Curso>();
        private readonly IPago _pago;

        public InscripcionService(IPago pago)
        {
            _pago = pago;
        }

        public void RegistrarEstudiante(string nombre, int edad)
        {
            var estudiante = new Estudiante(nombre, edad);
            _estudiantes.Add(estudiante);
        }

        public void RegistrarCurso(string nombre, decimal valor, DateTime fechaIncio, DateTime fechaFin)
        {
            var curso = new Curso(nombre, valor, fechaIncio, fechaFin);
            _cursos.Add(curso);
        }

        public void Inscribir(Estudiante estudiante, Curso curso)
        {
            if (_pago.PagoProcesado(curso.Valor))
            {
                var inscripcion = new Inscripcion(estudiante, curso);
                _inscripcion.Add(inscripcion);
            }
            else
            {
                throw new Exception("El pago falló");
            }
        }

        public IEnumerable<Inscripcion> ObtenerInscripcionPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _inscripcion.FindAll(e => e.Curso.FechaInicio >= fechaInicio && e.Curso.FechaFin <= fechaFin);
        }

        public IEnumerable<Estudiante> ObtenerEstudiantes()
        {
            return _estudiantes;
        }

        public IEnumerable<Curso> ObtenerCursos()
        {
            return _cursos;
        }
    }
}
