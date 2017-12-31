using System;
using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain.Organizacion
{
    public class Area 
    {
        public int AreaId { get; set; }
        public String Nombre { get; set; }
        public int TerritorioId { get; set; }
        public Territorio Territorio { get; set; }
    }
}
