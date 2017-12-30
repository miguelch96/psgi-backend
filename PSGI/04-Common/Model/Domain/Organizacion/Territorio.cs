using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain.Organizacion
{
    public class Territorio : AuditEntity,ISoftDeleted
    {
        public int TerritorioId { get; set; }
        public int Nombre { get; set; }
        public bool Deleted { get; set; }
    }
}
