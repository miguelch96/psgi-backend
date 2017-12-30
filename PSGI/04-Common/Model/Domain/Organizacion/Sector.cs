using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain.Organizacion
{
    public class Sector : AuditEntity, ISoftDeleted
    {
        public int SectorId { get; set; }
        public int Nombre { get; set; }
        public Zona Zona { get; set; }
        public bool Deleted { get; set; }
    }
}
