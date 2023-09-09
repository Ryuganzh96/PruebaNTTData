using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitarLogisticsAPI.Utilidades
{
    public static class Constants
    {
        public const string Time_Zone_Night = "noche";
        public const string Time_Zone_Morning = "mañana";
        public const string Time_Zone_Afternoon = "tarde";
        public const string Weather_Rainy = "lluvioso";
        public const string Weather_Sunny = "soleado";
        public const string Latitude = "0.7457947";
        public const string Length = "-75.2330292";
        public const string Type_Success = "SUCCESS";
        public const string Type_Error = "ERROR";

    }

    public static class ExcepcionMessage
    {
        public const string Weather_Not_Exists = "El tipo de clima ingresado no se encuentra registrado";
        public const string Time_Delivery_Not_Exists = "No existe un tiempo de entrega estimado para los datos suminisstrados";

    }
}
