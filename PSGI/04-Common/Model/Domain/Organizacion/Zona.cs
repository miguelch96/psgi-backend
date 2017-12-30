using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain.Organizacion
{
    public class Zona : AuditEntity, ISoftDeleted
    {
        public int ZonaId { get; set; }
        public int Nombre { get; set; }
        public Area Area { get; set; }
        public bool Deleted { get; set; }
    }
}
