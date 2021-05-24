using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft.Entities
{
    public class Producto
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
    }
}
