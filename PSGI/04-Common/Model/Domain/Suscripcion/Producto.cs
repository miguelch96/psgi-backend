using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain.Suscripcion
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public int NroEdicion { get; set; }
        public int TipoProductoId { get; set; }
        public TipoProducto TipoProducto { get; set; }
        public IEnumerable<DetalleSuscripcion> Suscripciones { get; set; }
    }
}
