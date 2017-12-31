using System;
using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain.Organizacion
{
    public class Zona 
    {
        public int ZonaId { get; set; }
        public String Nombre { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
