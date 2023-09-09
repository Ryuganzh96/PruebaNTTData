using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MilitarLogisticsAPI.Models;
using MilitarLogisticsAPI.Request;
using MilitarLogisticsAPI.Response;

namespace MilitarLogisticsAPI.Utilidades
{
    public class Utils
    {
        static public void CalculatePartOfDay(string hour, out string time_zone) {

            if (IsMorningTime(hour))
            {
                time_zone = "Manana".ToLower();
            }
            else if (IsAfternoonTime(hour))
            {
                time_zone = "Tarde".ToLower();
            }
            else if (IsNightTime(hour))
            {
                time_zone = "Noche".ToLower();                
            }
            else
            {
                throw new Exception("la hora ingresada es invalida");
            }            
        }

        // Morning range: 00:00 to 11:59
        static bool IsMorningTime(string hour)
        {
            
            TimeSpan hourofDay = TimeSpan.Parse(hour);
            return hourofDay >= TimeSpan.Parse("00:00") && hourofDay <= TimeSpan.Parse("11:59");
        }

        // Afternoon range: de 12:00 a 18:59 
        static bool IsAfternoonTime(string hour)
        {
            
            TimeSpan hourofDay = TimeSpan.Parse(hour);
            return hourofDay >= TimeSpan.Parse("12:00") && hourofDay <= TimeSpan.Parse("18:59");
        }

        // Night time: de 19:00 a 23:59 
        static bool IsNightTime(string hour)
        {            
            TimeSpan hourofDay = TimeSpan.Parse(hour);
            return hourofDay >= TimeSpan.Parse("19:00") && hourofDay <= TimeSpan.Parse("23:59");
        }

        static public void CalculteAmountProvisions(List<Parametros> _parametros, ProvisionesRequest request, ref ProvisionesResponse _response) {

            List<Parametros> units_fibonacci = _parametros.Where(p => p.Tipo_parametro.ToLower().Contains("unidades")).ToList() ?? null;

            if (units_fibonacci == null)
            {
                throw new Exception("No se encontraron reglas para para el tipo_parametro \"Unidades\"");
            }

            if (units_fibonacci.FirstOrDefault(u => u.Parametro == request.Units.ToString()) == null)
            {
                _response.Supply_response = CalcularRange(request.Units);
            }
            else if (units_fibonacci.FirstOrDefault(u => u.Parametro == request.Units.ToString()) != null)
            {
                _response.Supply_response = int.Parse(units_fibonacci.FirstOrDefault(u => u.Parametro == request.Units.ToString()).Valor);
            }
        }

        static public int CalcularRange(int units)
        {
            int supplyResponse = 0;

            if (units > 10 && units <= 30)
            {
                supplyResponse = 30;
            }

            if (units > 30)
            {
                supplyResponse = units + 2;
            }

            return supplyResponse;
        }

        static public void CalculteTimeEstimate(List<Parametros> _parametros, ProvisionesRequest request, string time_zone, ref ProvisionesResponse _response) {

            var parameters_weather = _parametros.Where(p => p.Tipo_parametro.ToLower().Contains("clima;hora")).ToList();
            bool weatherExists = _parametros.Any(x =>x.Parametro.ToLower().Contains(request.Weather));

            if (weatherExists) 
            {
                if (time_zone == Constants.Time_Zone_Night)
                {
                    _response.Time_response = getTimeResponse(parameters_weather, time_zone);
                }

                if (request.Weather.ToLower() == Constants.Weather_Rainy)
                {
                    _response.Time_response = getTimeResponse(parameters_weather, request.Weather);
                }

                if (request.Weather.ToLower() == Constants.Weather_Sunny && time_zone == Constants.Time_Zone_Morning)
                {
                    _response.Time_response = getTimeResponse(parameters_weather, request.Weather,time_zone);
                }

                if (request.Weather.ToLower() == Constants.Weather_Sunny && time_zone == Constants.Time_Zone_Afternoon)
                {
                    _response.Time_response = getTimeResponse(parameters_weather, request.Weather, time_zone);                    
                }

                if (!string.IsNullOrEmpty(_response.Time_response)) {
                    CalculateDeliveryDate(request,ref _response);
                    _response.Latitude_response = Constants.Latitude;
                    _response.Lenght_response= Constants.Length;
                }
                else {
                    throw new Exception(ExcepcionMessage.Time_Delivery_Not_Exists);
                }
            }
            else
            {
                throw new Exception(ExcepcionMessage.Weather_Not_Exists);
            }
        }

        static public string getTimeResponse(List<Parametros> parameters_weather, string Weather, string time_zone = "") {

            string response = string.Empty;

            if (!string.IsNullOrEmpty(Weather) && string.IsNullOrEmpty(time_zone)) 
            {
                response = parameters_weather.FirstOrDefault(ec => ec.Parametro.ToLower().Contains(Weather.ToLower()))?.Valor ?? string.Empty;
            }
            else if(!string.IsNullOrEmpty(Weather) && !string.IsNullOrEmpty(time_zone))
            {
                response = parameters_weather.FirstOrDefault(x => x.Parametro.ToLower().Contains(Weather.ToLower()) && x.Parametro.ToLower().Contains(time_zone))?.Valor ?? string.Empty;
            }
            return response;
        
        }

        static public void CalculateDeliveryDate(ProvisionesRequest request, ref ProvisionesResponse _response) 
        {
            string[] hoursEstimate = _response.Time_response.Split(';');

            int[] hoursTotal = hoursEstimate.Select(int.Parse).ToArray();

            if (hoursTotal.Length > 0)
            {
                double hourMax = (double)hoursTotal.Max();
                _response.Date_response = request.Date.AddHours(hourMax);
                _response.Hour_response = _response.Date_response.ToString("HH:mm");
            }
        }
    }

}




