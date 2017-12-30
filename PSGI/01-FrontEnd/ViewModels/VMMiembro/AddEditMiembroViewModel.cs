using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Domain;
using Model.Domain.Estatico;

namespace FrontEnd.ViewModels.VMMiembro
{
    public class AddEditMiembroViewModel
    {
        public Miembro Miembro { get; set; } = new Miembro();
        public IEnumerable<Division> Divisiones { get; set; }
        public IEnumerable<Estado> Estados { get; set; }
        public IEnumerable<TipoDocumento> TiposDocumento { get; set; }
        public IEnumerable<TipoMiembro> TiposMiembro { get; set; }
    }
}