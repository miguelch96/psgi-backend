using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain
{
    public class Sector : AuditEntity, ISoftDeleted
    {
        public int SectorId { get; set; }
        public int Nombre { get; set; }
        public Zona Zona { get; set; }
        public bool Deleted { get; set; }
    }
}
