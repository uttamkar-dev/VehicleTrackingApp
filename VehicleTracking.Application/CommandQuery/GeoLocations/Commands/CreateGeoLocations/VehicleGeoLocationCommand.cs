using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Application.Helper;

namespace VehicleTracking.Application.CommandQuery.GeoLocations.Commands.CreateGeoLocations
{
    public record VehicleGeoLocationCommand(string City, string State, string Country
     , decimal Latitude, decimal Longitude, string Address, DateTime TrackingDate, int UserId, string VehicleNo)
     : IRequest<Message>;
}
