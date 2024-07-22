using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DOMINIO
{
    public class Estudiante
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public Estudiante(string nombre, int edad)
        {
            if (edad < 18)
                throw new ArgumentException("El estudiante debe ser mayor de edad");

            Nombre = nombre;
            Edad = edad;
        }
    }
}
