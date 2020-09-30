using MediatR;
using RaceTrack.Web.CQRS.DTO;
using RaceTrack.Web.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RaceTrack.Web.CQRS.Commands
{
    public class AddVehicleOnTrackCommand : AddNewVehicleOnTrack, IRequest<Response<AddVehicleOnTrackCommand>>
    {

    }
    public class AddVehicleOnTrackCommandHandler : IRequestHandler<AddVehicleOnTrackCommand, Response<AddVehicleOnTrackCommand>>
    {
        private readonly TrackDbContext _db;
        
        public AddVehicleOnTrackCommandHandler(TrackDbContext context)
        {
            _db = context;
        }

        public async Task<Response<AddVehicleOnTrackCommand>> Handle(AddVehicleOnTrackCommand request, CancellationToken cancellationToken)
        {
            if (!IsTrackFull())
            {

                if (request.Type.Equals("Car") && (request.AreThereTwoStrapsOnVehicle && request.HaveLessThan85PerTireWear))
                {
                    TrackVehicle trackVehicle = new TrackVehicle() { Identification = request.Identification, IsOnTrack = true, Type = request.Type };
                    _db.Add(trackVehicle);
                    _db.SaveChanges();
                    return new Response<AddVehicleOnTrackCommand>(request, "Car Added On Track", "");
                }
                else if (request.Type.Equals("Truck") && (request.AreThereTwoStrapsOnVehicle && request.IsNotLiftedMoreThan5Inches))
                {
                    TrackVehicle trackVehicle = new TrackVehicle() { Identification = request.Identification, IsOnTrack = true, Type = request.Type };
                    _db.Add(trackVehicle);
                    _db.SaveChanges();
                    return new Response<AddVehicleOnTrackCommand>(request, "Truck Added On Track", "");
                }
                else
                {
                    return new Response<AddVehicleOnTrackCommand>(request, "", $"{request.Type} does not match the citeria to be on track!");
                }
            }
            else
            {
                return new Response<AddVehicleOnTrackCommand>(request, "", "Track is Full. Only 5 vehicles can be on track at a time !");
            }
        }

        private bool IsTrackFull()
        {
            if (_db.TrackVehicles.Count() >= 5)
            {
                return true;
            }
            else { return false; }
        }
    }
}
