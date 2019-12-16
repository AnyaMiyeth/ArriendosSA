using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace NgNetCore.Models
{
    public class Inmueble
    {
        [Key]
        public string NumeroMatricula { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Departamento { get; set; }
        [Required]
        public string Ciudad { get; set; }
        
         [Required]
        public decimal Valor { get; set; }

    }
}
