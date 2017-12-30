using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain
{
    public class Grupo : AuditEntity, ISoftDeleted
    {
        public int GrupoId { get; set; }
        public int Nombre { get; set; }
        public Sector Sector { get; set; }
        public bool Deleted { get; set; }
    }
}
