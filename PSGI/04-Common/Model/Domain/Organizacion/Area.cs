using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain.Organizacion
{
    public class Area : AuditEntity, ISoftDeleted
    {
        public int AreaId { get; set; }
        public int Nombre { get; set; }
        public int TerritorioId { get; set; }
        public Territorio Territorio { get; set; }
        public bool Deleted { get; set; }
    }
}
