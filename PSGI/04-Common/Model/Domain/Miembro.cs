using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.CustomFilters;
using Model.Domain.Estatico;
using Model.Domain.Examen;
using Model.Domain.Organizacion;
using Model.Helper;

namespace Model.Domain
{
    public class Miembro : AuditEntity, ISoftDeleted
    {
       
        public int MiembroId { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        //DOCUMENTO
        [DisplayName("Tipo de Documento")]
        public int TipoDocumentoId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }

        [DisplayName("Número de Documento")]
        public String NroDocumento { get; set; }

        public Enums.Sexo Sexo { get; set; }

        //TIPO MIEMBRO
        [DisplayName("Tipo Miembro")]
        public int TipoMiembroId { get; set; }
        public TipoMiembro TipoMiembro { get; set; }

        //DIVISION 
        [DisplayName("Division")]
        public int DivisionId { get; set; }
        public Division Division { get; set; }

        //GRUPO
        [DisplayName("Grupo")]
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }

        //ESTADO
        [DisplayName("Estado")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        public ICollection<ExamenMiembro> Examenes { get; set; }

        //GRADO
        public int? GradoId { get; set; }
        public Grado Grado { get; set; }
   
        public bool Deleted { get; set; }
    }
}
