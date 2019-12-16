using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NgNetCore.Models
{
    public class Ruta
    {
        [Required]
        [Key]
        public string Codigo { get; set; }
        [Required]
        public string CiudadOrigen { get; set; }
        [Required]
        public string CiudadDestino { get; set; }
        [Required]
        public decimal Costo { get; set; }
    }
}
