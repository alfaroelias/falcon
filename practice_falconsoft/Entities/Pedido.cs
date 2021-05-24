using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft.Entities
{
    public class Pedido
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<PedidoDetalle> Detalle { get; set; }
    }
}
