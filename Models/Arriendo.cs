using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NgNetCore.Models
{
    public class Arriendo
    {
        public Arriendo()
        {

        }
        public Arriendo(Cliente cliente, Inmueble inmueble, int mes)
        {
            Cliente = cliente;
            Inmueble = inmueble;
            Mes = mes;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public Cliente Cliente { get; set; }
        [Required]
        public Inmueble Inmueble { get; set; }
        [Required]
        public int Mes { get; set; }
        [Required]
        public decimal ValorContrato { get=>Inmueble.Valor*Mes; set { } }
    }
}
