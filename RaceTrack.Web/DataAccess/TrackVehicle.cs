using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTrack.Web.DataAccess
{
    public class TrackVehicle
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Identification { get; set; }
        public bool IsOnTrack { get; set; }
    }
}
