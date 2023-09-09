using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilitarLogisticsAPI.Data;
using MilitarLogisticsAPI.Manejadores;
using MilitarLogisticsAPI.Models;
using MilitarLogisticsAPI.Request;
using MilitarLogisticsAPI.Response;
using MilitarLogisticsAPI.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitarLogisticsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvisionesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ProvisionesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> CalculateProvisions([FromBody] ProvisionesRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                List<Parametros> _parametros = await _db.Parametros.OrderBy(p => p.Tipo_parametro).ToListAsync() ?? null;

                if (_parametros == null)
                {
                    throw new Exception("No se encontraron datos en la tabla parametros");
                }

                ProvisionesResponse _response = new();
                string time_zone;
                Utils.CalculteAmountProvisions(_parametros, request,ref _response);            
                Utils.CalculatePartOfDay(request.Hour, out time_zone);
                Utils.CalculteTimeEstimate(_parametros, request, time_zone, ref _response);
                Utils.CalculateDeliveryDate(request, ref _response);

                bool resultadoInsert = await new ManejadorProvisiones_logs(_db).insert(_response, request,Constants.Type_Success);

                return Ok();
            }
            catch (Exception ex)
            {
                string message = string.Empty;
                if (ModelState.Values.Any(v => v.Errors != null))
                {
                    message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)) ?? string.Empty;
                }
                bool resultadoInsert = await new ManejadorProvisiones_logs(_db).insert(null, request, Constants.Type_Success);
                return BadRequest(ex.Message + " " + message);
            }
        }
    }
}
