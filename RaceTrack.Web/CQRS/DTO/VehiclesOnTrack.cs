using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTrack.Web.CQRS
{
    public class VehiclesOnTrack
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Identification { get; set; }
    }
}
