using Garage2G1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2G1.Data
{
    public class ParkedVehicleContext : DbContext
    {

        public ParkedVehicleContext(DbContextOptions<ParkedVehicleContext> options) : base(options)
        {

        }

        public DbSet<ParkedVehicle> ParkedVehicle { get; set; }

    }
}
