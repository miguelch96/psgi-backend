using System;
using System.Collections.Generic;
using Common.CustomFilters;
using Model.Helper;

namespace Model.Domain.Examen
{
    public class Examen 
    {
        public int ExamenId { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public String Ubicacion { get; set; }
        public DateTime FechaInicioInscripcion { get; set; }
        public DateTime FechaFinInsripcion { get; set; }
        public DateTime FechaExamen { get; set; }

        public ICollection<ExamenMiembro> Inscritos { get; set; }

    }
}
