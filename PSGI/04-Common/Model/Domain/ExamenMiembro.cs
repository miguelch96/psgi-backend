using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class ExamenMiembro
    {
        public int ExamenMiembroId { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public int MiembroId { get; set; }
        public Miembro Miembro { get; set; }
        public int ExamenId { get; set; }
        public int GradoObtenidoId { get; set; }
        public Grado GradoObtenido { get; set; }
        public bool Aprobado { get; set; }
        public Examen Examen { get; set; }
    }
}
