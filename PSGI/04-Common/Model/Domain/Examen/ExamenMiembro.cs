using System;

namespace Model.Domain.Examen
{
    public class ExamenMiembro
    {
        public int ExamenMiembroId { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public int MiembroId { get; set; }
        public Miembro Miembro { get; set; }
        public int ExamenId { get; set; }
        public int? GradoObtenidoId { get; set; }
        public Grado GradoObtenido { get; set; }
        public bool Asistio { get; set; } = false;
        public bool Aprobado { get; set; } = false;
        public Domain.Examen.Examen Examen { get; set; }
    }
}
