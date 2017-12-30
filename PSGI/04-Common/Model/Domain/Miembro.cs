using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain
{
    public class Miembro : AuditEntity, ISoftDeleted
    {
        public int MiembroId { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Enums.TipoDocumento TipoDocumento { get; set; }
        public String NroDocumento { get; set; }
        public Enums.Sexo Sexo { get; set; }
        public Enums.TipoMiembro TipoMiembro { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
        public Enums.Estado Estado { get; set; }
        public ICollection<ExamenMiembro> Examenes { get; set; }
        public int? GradoId { get; set; }
        public Grado Grado { get; set; }
        public bool Deleted { get; set; }
    }
}
