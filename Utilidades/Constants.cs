using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitarLogisticsAPI.Utilidades
{
    public static class Constants
    {
        public const string Time_Zone_Night = "noche";
        public const string Time_Zone_Morning = "manana";
        public const string Time_Zone_Afternoon = "tarde";
        public const string Weather_Rainy = "lluvioso";
        public const string Weather_Sunny = "soleado";
        public const string Latitude = "0.7457947";
        public const string Length = "-75.2330292";
        public const string Type_Success = "SUCCESS";
        public const string Type_Error = "ERROR";
        public const string Time_Estimate = "El tiempo estimado de entrega es {0} {1}";
        public const string Hours = "horas";

    }

    public static class ExcepcionMessage
    {
        public const string Weather_Not_Exists = "El tipo de clima ingresado no se encuentra registrado";
        public const string Time_Delivery_Not_Exists = "No existe un tiempo de entrega estimado para los datos suminisstrados";
        public const string Units_Invalid = "La cantidad de provisiones solicitadas no es valida";
        public const string Units_NotExists = "No se encontraron reglas para para la cantidad de unidades requeridas";
        public const string Units_Fibonacci_Invalid = "No se encontraron reglas para para el tipo_parametro \"Unidades\"";
    }
}
