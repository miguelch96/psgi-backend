using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain.Suscripcion
{
    public class DetalleSuscripcion
    {
        public int DetalleSuscripcionId { get; set; }
        public int SuscripcionId { get; set; }
        public Suscripcion Suscripcion { get; set; }
        public int ProductoId  { get; set; }
        public Producto Producto  { get; set; }
        public int TipoSuscripcionId { get; set; }
        public TipoSuscripcion TipoSuscripcion { get; set; }
        public int Cantidad { get; set; }
        public float Subtotal { get; set; } 
    }
}
