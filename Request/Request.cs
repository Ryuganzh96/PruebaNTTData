using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitarLogisticsAPI.Request
{
    public class ProvisionesRequest
    {
        
        public string Lenght { get; set; }

        public string Latitude { get; set; }

        public DateTime Date { get; set; }

        public string Hour { get; set; }

        public string Weather { get; set; }

        public int Units { get; set; }
    }
}
