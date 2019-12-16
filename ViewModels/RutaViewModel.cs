using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NgNetCore.ViewModels
{
    public class RutaViewModel
    {
        [Required]
       
        public string Codigo { get; set; }
        [Required]
        public string CiudadOrigen { get; set; }
        [Required]
        public string CiudadDestino { get; set; }
        [Required]
        public decimal Costo { get; set; }
    }
}
