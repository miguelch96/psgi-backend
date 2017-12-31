using System;
using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain.Organizacion
{
    public class Grupo 
    {
        public int GrupoId { get; set; }
        public String Nombre { get; set; }
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
    }
}
