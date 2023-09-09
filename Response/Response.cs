using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitarLogisticsAPI.Response 
{ 
    public class ProvisionesResponse
    {
        public string Lenght_response { get; set; }

        public string Latitude_response { get; set; }

        public DateTime Date_response { get; set; }

        public string Hour_response { get; set; }

        public string Time_response { get; set; }

        public int Supply_response { get; set; }
    }
}
