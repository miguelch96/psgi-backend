using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain
{
    public class Area : AuditEntity, ISoftDeleted
    {
        public int AreaId { get; set; }
        public int Nombre { get; set; }
        public Territorio Territorio { get; set; }
        public bool Deleted { get; set; }
    }
}
