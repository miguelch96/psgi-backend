using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.CustomFilters;
using Model.Domain.Estatico;
using Model.Helper;

namespace Model.Domain
{
    public class Miembro : AuditEntity, ISoftDeleted
    {
       
        public int MiembroId { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }

        //DOCUMENTO
        public byte TipoDocumentoId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public String NroDocumento { get; set; }

        public Enums.Sexo Sexo { get; set; }

        //TIPO MIEMBRO
        public byte TipoMiembroId { get; set; }
        public TipoMiembro TipoMiembro { get; set; }

        //GRUPO
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }

        //ESTADO
        public byte EstadoId { get; set; }
        public Estado Estado { get; set; }

        public ICollection<ExamenMiembro> Examenes { get; set; }

        //GRADO
        public byte? GradoId { get; set; }
        public Grado Grado { get; set; }

        public bool Deleted { get; set; }
    }
}
