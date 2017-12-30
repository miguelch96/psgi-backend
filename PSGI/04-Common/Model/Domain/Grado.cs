using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain
{
    public class Grado : AuditEntity,ISoftDeleted
    {
        public byte GradoId { get; set; }
        public String Nombre { get; set; }
        public bool Deleted { get; set; }
    }
}
