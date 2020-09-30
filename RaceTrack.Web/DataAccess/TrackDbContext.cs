using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaceTrack.Web.CQRS.Commands;

namespace RaceTrack.Web.DataAccess
{
    public class TrackDbContext : DbContext
    {
        public TrackDbContext()
        {

        }
        public TrackDbContext(DbContextOptions<TrackDbContext> options) : base(options)
        {

        }
        public DbSet<TrackVehicle> TrackVehicles { get; set; }
    }
}
