using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Entity.Dtos;

namespace VehicleTracking.Application.CommandQuery.GeoLocations.Queries.GetGeoLocationByUser
{
    public record GetGeoLocationByUserQuery(int userId) : IRequest<List<VehicleGeoLocationDto>>;
}
