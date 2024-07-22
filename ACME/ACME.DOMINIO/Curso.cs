using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DOMINIO
{
    public class Curso
    {
        public string Nombre { get; set; }

        public decimal Valor { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public Curso(string nombre, decimal valor, DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio >= fechaFin)
            {
                throw new ArgumentException("Fecha inicio debe ser previa a fecha fin");
            }

            Nombre = nombre;
            Valor = valor;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }
    }
}
