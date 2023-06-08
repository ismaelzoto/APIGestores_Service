using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIGestores_Service.Modelo;

namespace APIGestores_Service.Data
{
    public class APIGestores_ServiceContext : DbContext
    {
        public APIGestores_ServiceContext (DbContextOptions<APIGestores_ServiceContext> options)
            : base(options)
        {
        }

        public DbSet<APIGestores_Service.Modelo.Gestores> Gestores { get; set; }
    }
}
