using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitarLogisticsAPI.Models
{
    public class Parametros
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Parametro { get; set; }

        [Required]
        public string Tipo_parametro { get; set; }

        [Required]
        public string Valor { get; set; }
    }
}
