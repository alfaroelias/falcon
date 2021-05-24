using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft.Entities
{
    public class PedidoDetalle
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }
        
        public Guid ProductoId { get; set; }

        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; }
        public Guid PedidoId { get; set; }
    }
}
