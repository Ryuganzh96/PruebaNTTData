using Microsoft.EntityFrameworkCore;
using MilitarLogisticsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitarLogisticsAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base (option)
        {

        }

        public DbSet<Provisiones_logs> Provisiones_logs { get; set; }

        public DbSet<Parametros> Parametros { get; set; }
    }
}
