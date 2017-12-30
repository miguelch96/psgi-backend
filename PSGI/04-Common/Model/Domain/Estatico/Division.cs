using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain.Estatico
{
    public class Division
    {
        public int DivisionId { get; set; }
        public String Nombre { get; set; }
        public String Siglas { get; set; }
        public String Descripcion { get; set; }
    }
}
