using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain
{
    public class Territorio : AuditEntity,ISoftDeleted
    {
        public int TerritorioId { get; set; }
        public int Nombre { get; set; }
        public bool Deleted { get; set; }
    }
}
