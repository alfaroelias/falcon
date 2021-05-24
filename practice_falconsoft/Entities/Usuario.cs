using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft.Entities
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
