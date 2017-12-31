using System;
using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain.Organizacion
{
    public class Sector 
    {
        public int SectorId { get; set; }
        public String Nombre { get; set; }
        public int ZonaId { get; set; }
        public Zona Zona { get; set; }
    }
}
