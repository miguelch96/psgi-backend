using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain.Suscripcion
{
    public class Suscripcion
    {
        public int SuscripcionId { get; set; }
        public float Total { get; set; }
        public int MiembroId { get; set; }
        public Miembro Miembro { get; set; }
        public IEnumerable<DetalleSuscripcion> Productos { get; set; }  
    }
}
