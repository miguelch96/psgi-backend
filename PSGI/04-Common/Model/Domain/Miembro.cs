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
        public Enums.Gender Genre { get; set; }
        public bool Deleted { get; set; }
    }
}
