using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NgNetCore.ViewModels
{
    public class ArriendoRegistrarRequest
    {
        [Required(ErrorMessage = "La identificación es requerida")]
        public string ClienteId { get; set; }
        [Required(ErrorMessage = "La matricula es requerida")]
        public string InmuebleMatricula { get; set; }
        [Required]
        [Range(3, 12, ErrorMessage = "El valor del mes debe estar entre {1} y {2}.")]
        public int Mes { get; set; }
    }
}
