using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DOMINIO
{
    public class Inscripcion
    {
        public Estudiante Estudiante { get; set; }
        public Curso Curso { get; set; }

        public Inscripcion(Estudiante estudiante, Curso curso)
        {
            Estudiante = estudiante;
            Curso = curso;
        }
    }
}
