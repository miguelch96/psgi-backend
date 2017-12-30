using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain
{
    public class Examen : AuditEntity,ISoftDeleted
    {
        public int ExamenId { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public String Ubicacion { get; set; }
        public DateTime FechaInicioInscripcion { get; set; }
        public DateTime FechaFinInsripcion { get; set; }
        public DateTime FechaExamen { get; set; }

        public ICollection<ExamenMiembro> Inscritos { get; set; }

        public bool Deleted { get; set; }
    }
}
