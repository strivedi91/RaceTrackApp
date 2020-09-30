using MediatR;
using RaceTrack.Web.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;

namespace RaceTrack.Web.CQRS.Queries
{
    public class GetAllVehiclesOnTrack : IRequest<IEnumerable<VehiclesOnTrack>>
    {
    }

    public class GetAllVehiclesOnTrackHandler : IRequestHandler<GetAllVehiclesOnTrack, IEnumerable<VehiclesOnTrack>>
    {
        private readonly TrackDbContext _db;
        public GetAllVehiclesOnTrackHandler(TrackDbContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<VehiclesOnTrack>> Handle(GetAllVehiclesOnTrack request, CancellationToken cancellationToken)
        {
            return _db.TrackVehicles.Where(x => x.IsOnTrack == true)
                .Select(x => new VehiclesOnTrack { Id = x.Id, Type = x.Type, Identification = x.Identification }).ToList();
        }
    }
}
