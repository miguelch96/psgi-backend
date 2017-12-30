using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain.Organizacion
{
    public class Grupo : AuditEntity, ISoftDeleted
    {
        public int GrupoId { get; set; }
        public int Nombre { get; set; }
        public Sector Sector { get; set; }
        public bool Deleted { get; set; }
    }
}
