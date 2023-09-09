using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MilitarLogisticsAPI.Request;
using MilitarLogisticsAPI.Response;
using MilitarLogisticsAPI.Models;
using MilitarLogisticsAPI.Data;
using System.Text.Json;

namespace MilitarLogisticsAPI.Manejadores
{
    public class ManejadorProvisiones_logs
    {
        private readonly ApplicationDbContext _db;

        public ManejadorProvisiones_logs(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> insert(ProvisionesResponse _response, ProvisionesRequest request, string type)
        {

            Provisiones_logs logNew = new Provisiones_logs
            {
                Request = JsonSerializer.Serialize(request),
                Response = _response !=null ? JsonSerializer.Serialize(_response) : string.Empty,
                Type = type,
                Date = DateTime.Now.ToString()
            };
            _db.Provisiones_logs.Add(logNew);
            await _db.SaveChangesAsync();

            return !string.IsNullOrEmpty(logNew.ID.ToString());
        }
    }
}
