using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitarLogisticsAPI.Models
{
    public class Provisiones_logs
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Request { get; set; }

        [Required]
        public string Response { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Date { get; set; }

    }
}
